using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.Models;


namespace ContactManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwt;

        public AuthController(AppDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public IActionResult Register(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User Registered");
        }

        [HttpPost("login")]
        public IActionResult Login(UserInfo login)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.EmailId == login.EmailId && x.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _jwt.GenerateToken(user.EmailId, user.Role);

            return Ok(new { token });
        }
    }
}