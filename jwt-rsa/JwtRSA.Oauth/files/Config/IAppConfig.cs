namespace JwtRSA.Oauth.Config
{
    public interface IAppConfig
    {
        public string JwtRsaPrivateKey { get; }

        public string JwtRsaPublicKey { get; }
    }
}