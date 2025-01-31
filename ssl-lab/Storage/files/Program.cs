using System;
using System.Security.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Storage.Helpers;

namespace Storage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.ConfigureHttpsDefaults(configureOptions =>
                        {
                            configureOptions.SslProtocols = GetSslAllowedProtocols();
                            configureOptions.ServerCertificate = CertificateHelper.GetCertificate();
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });

        private static SslProtocols GetSslAllowedProtocols()
        {
            var sslAllowedProtocols = Environment.GetEnvironmentVariable("SslAllowedProtocols");
            SslProtocols? sslProtocols = null;

            foreach (var item in sslAllowedProtocols.Split(","))
            {
                var protocol = GetProtocolType(item);
                if (protocol != null)
                {
                    if (sslProtocols == null)
                        sslProtocols = protocol;
                    else
                        sslProtocols = sslProtocols | protocol;
                }
            }

            if (!sslProtocols.HasValue)
                throw new ArgumentException("Não foi possível configurar o ssl.");

            return sslProtocols.Value;
        }

        private static SslProtocols? GetProtocolType(string protocolType)
        {
            switch (protocolType?.ToLower())
            {
                case "ssl":
#pragma warning disable CS0618 // Type or member is obsolete
                    return SslProtocols.Ssl3;
#pragma warning restore CS0618 // Type or member is obsolete
                case "tls":
#pragma warning disable SYSLIB0039 // Type or member is obsolete
                    return SslProtocols.Tls;
#pragma warning restore SYSLIB0039 // Type or member is obsolete
                case "tls11":
#pragma warning disable SYSLIB0039 // Type or member is obsolete
                    return SslProtocols.Tls11;
#pragma warning restore SYSLIB0039 // Type or member is obsolete
                case "tls12":
                    return SslProtocols.Tls12;
                case "tls13":
                    return SslProtocols.Tls12;
                default:
                    return null;
            }
        }
    }
}