using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopEz.Models;
using ShopEz.DTOs;
using ShopEz.Repositories;
using ShopEz.Services;
using Microsoft.AspNetCore.Authorization;
using ShopEz.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopEz.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IConfiguration config;
        public AuthController(AppDbContext _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            //  ADMIN LOGIN
            if (dto.Email == "admin@mail.com" && dto.Password == "admin123")
            {
                var adminToken = GenerateToken("admin@mail.com", "Admin");
                return Ok(new { token = adminToken });
            }

            //  USER LOGIN
            var user = db.Users.FirstOrDefault(x =>
                x.Email == dto.Email && x.Password == dto.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var userToken = GenerateToken(user.Email, "User");

            return Ok(new { token = userToken });
        }

        private string GenerateToken(string email, string role)
        {
            var jwt = config.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, email),
        new Claim(ClaimTypes.Role, role)
    };

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}