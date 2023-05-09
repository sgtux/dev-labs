using System.Linq;
using JwtRSA.Oauth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JwtRSA.Oauth.Controllers;

[Authorize]
[Route("[controller]")]
public class UserController : BaseController
{
    private IConfiguration _config;

    public UserController(IConfiguration config) => _config = config;

    public User Get()    
    {
        var value = _config["Logging"];
        return Users.FirstOrDefault(p => p.Id == UserId);
    }
}