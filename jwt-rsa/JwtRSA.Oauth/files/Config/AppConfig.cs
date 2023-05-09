using Microsoft.Extensions.Configuration;

namespace JwtRSA.Oauth.Config
{
    public class AppConfig : IAppConfig
    {
        public AppConfig (IConfiguration config)
        {
            JwtRsaPrivateKey = config["PrivateKey"];
            JwtRsaPublicKey = config["PublicKey"];
        }

        public string JwtRsaPrivateKey { get; }

        public string JwtRsaPublicKey { get;  }
    }
}