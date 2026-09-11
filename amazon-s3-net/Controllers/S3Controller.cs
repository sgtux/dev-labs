using amazon_s3_net.Services;
using Microsoft.AspNetCore.Mvc;

namespace amazon_s3_net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class S3Controller : ControllerBase
{
    private readonly IS3Service _s3Service;

    public S3Controller(IS3Service s3Service)
    {
        _s3Service = s3Service;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
    {
        if (file is null || file.Length == 0)
        {
            return BadRequest("Nenhum arquivo enviado.");
        }

        await using var stream = file.OpenReadStream();
        await _s3Service.UploadAsync(file.FileName, stream, file.ContentType, cancellationToken);

        return Ok(new { file.FileName });
    }

    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> Download(string fileName, CancellationToken cancellationToken)
    {
        try
        {
            var (content, contentType) = await _s3Service.DownloadAsync(fileName, cancellationToken);
            return File(content, contentType, fileName);
        }
        catch (FileNotFoundException)
        {
            return NotFound($"Arquivo '{fileName}' não encontrado.");
        }
    }
}
