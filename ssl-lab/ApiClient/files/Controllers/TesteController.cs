using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Controllers
{
    [ApiController]
    [Route("")]
    public class TesteController : ControllerBase
    {
        private HttpClient _httpClient;
        public TesteController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("HttpClientWithSSLUntrusted");
        }

        [HttpGet]
        public async Task<object> Get([FromQuery] string protocolType)
        {
            try
            {
                var protocol = GetProtocolType(protocolType);
                if (!protocol.HasValue)
                    return BadRequest("Protocolo informado é inválido");
                ServicePointManager.SecurityProtocol = protocol.Value;
                var storageApiUrl = Environment.GetEnvironmentVariable("STORAGE_API_URL");
                var request = new HttpRequestMessage(HttpMethod.Get, storageApiUrl);
                var response = await _httpClient.Send(request).Content.ReadAsStringAsync();
                return Ok(response);
            }
            catch (NotSupportedException ex)
            {
                return Ok($"Erro: {ex.Message}");
            }
        }

        private SecurityProtocolType? GetProtocolType(string protocolType)
        {
            switch (protocolType?.ToLower())
            {
                case "ssl":
#pragma warning disable CS0618 // Type or member is obsolete
                    return SecurityProtocolType.Ssl3;
#pragma warning restore CS0618 // Type or member is obsolete
                case "tls":
                    return SecurityProtocolType.Tls;
                case "tls11":
                    return SecurityProtocolType.Tls11;
                case "tls12":
                    return SecurityProtocolType.Tls12;
                case "tls13":
                    return SecurityProtocolType.Tls12;
                default:
                    return null;
            }
        }
    }
}