using System;
using System.Security.Cryptography;
using JwtRSA.Oauth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using Microsoft.Extensions.Configuration;
using JwtRSA.Oauth.Config;

namespace JwtRSA.Oauth.Controllers;

[Route("[controller]")]
public class TokenController : BaseController
{
    private IAppConfig _config;

    public TokenController(IAppConfig config) => _config = config;

    [HttpPost]
    public ActionResult Post([FromBody] User model)
    {
        var user = Users.FirstOrDefault(p => model.Email == p.Email);
        if (user == null || user.Password != model.Password)
            return Unauthorized();

        using RSA rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(Convert.FromBase64String(_config.JwtRsaPrivateKey), out int _);

        var key = new RsaSecurityKey(rsa);
        

        var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };

        var jwt = new JwtSecurityToken(
            claims: new Claim[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email),
                    new Claim("Role", user.Role.ToString())
            },
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signingCredentials
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Ok(new { token });
    }
}