using System;
using System.Collections.Generic;
using System.Linq;
using JwtRSA.Oauth.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtRSA.Oauth.Controllers;

public class BaseController : ControllerBase
{
    protected static List<User> Users = new List<User>()
    {
        new User() { Id = 1, Name = "Admin", Email = "admin@mail.com", Password = "123qwe", Role = 1 }
    };

    protected int UserId => Convert.ToInt32(User.Claims.First(p => p.Type == "Id").Value);
}