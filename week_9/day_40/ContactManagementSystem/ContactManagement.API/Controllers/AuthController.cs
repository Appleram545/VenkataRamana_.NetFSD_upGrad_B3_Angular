using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if(username =="admin" && password == "123")
            {
                return Ok("dummy-token");
            }
            return Unauthorized();
        }
        
    }
}