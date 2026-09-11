using Amazon.S3;
using amazon_s3_net.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var s3ServiceUrl = builder.Configuration["S3:ServiceURL"];
if (!string.IsNullOrWhiteSpace(s3ServiceUrl))
{
    // LocalStack não resolve virtual-hosted-style buckets, então ForcePathStyle é obrigatório aqui.
    builder.Services.AddSingleton<IAmazonS3>(_ => new AmazonS3Client(new AmazonS3Config
    {
        ServiceURL = s3ServiceUrl,
        ForcePathStyle = true
    }));
}
else
{
    builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
    builder.Services.AddAWSService<IAmazonS3>();
}

// Lazy<IAmazonS3> adia a criação do client (e a resolução de credenciais) até o primeiro uso real,
// em vez de falhar assim que o DI monta as dependências do controller.
builder.Services.AddSingleton(sp => new Lazy<IAmazonS3>(() => sp.GetRequiredService<IAmazonS3>()));

builder.Services.Configure<S3Options>(builder.Configuration.GetSection("S3"));
builder.Services.AddScoped<IS3Service, S3Service>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
