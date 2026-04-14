using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Models;
using ContactManagement.Services;

namespace ContactManagement.Services
{
    public class JwtService
    {
        private readonly string key = "THIS_IS_MY_SECRET_KEY_12345";

        public string GenerateToken(string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };
            var keyBytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(keyBytes, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.Now.AddHours(1),
               signingCredentials: creds
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public SymmetricSecurityKey GetKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}