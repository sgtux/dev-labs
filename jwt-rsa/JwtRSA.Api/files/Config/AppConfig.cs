using Microsoft.Extensions.Configuration;

namespace JwtRSA.Api.Config
{
    public class AppConfig : IAppConfig
    {
        public AppConfig (IConfiguration config) => JwtRsaPublicKey = config["PublicKey"];

        public string JwtRsaPublicKey { get;  }
    }
}