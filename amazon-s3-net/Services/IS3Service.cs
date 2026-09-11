namespace amazon_s3_net.Services;

public interface IS3Service
{
    Task UploadAsync(string fileName, Stream content, string? contentType, CancellationToken cancellationToken = default);

    Task<(Stream Content, string ContentType)> DownloadAsync(string fileName, CancellationToken cancellationToken = default);
}
