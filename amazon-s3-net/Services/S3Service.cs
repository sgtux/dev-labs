using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;

namespace amazon_s3_net.Services;

public class S3Service : IS3Service
{
    private readonly Lazy<IAmazonS3> _s3Client;
    private readonly string _bucketName;

    public S3Service(Lazy<IAmazonS3> s3Client, IOptions<S3Options> options)
    {
        _s3Client = s3Client;
        _bucketName = options.Value.BucketName;
    }

    public async Task UploadAsync(string fileName, Stream content, string? contentType, CancellationToken cancellationToken = default)
    {
        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName,
            InputStream = content,
            ContentType = string.IsNullOrWhiteSpace(contentType) ? "application/octet-stream" : contentType
        };

        await _s3Client.Value.PutObjectAsync(request, cancellationToken);
    }

    public async Task<(Stream Content, string ContentType)> DownloadAsync(string fileName, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _s3Client.Value.GetObjectAsync(_bucketName, fileName, cancellationToken);

            var memoryStream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(memoryStream, cancellationToken);
            memoryStream.Position = 0;

            return (memoryStream, response.Headers.ContentType ?? "application/octet-stream");
        }
        catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            throw new FileNotFoundException($"Arquivo '{fileName}' não encontrado no bucket.", fileName, ex);
        }
    }
}
