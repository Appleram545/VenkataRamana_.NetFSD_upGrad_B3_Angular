using ShopEz.Models;
using ShopEz.DTOs;
using ShopEz.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopEz.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public User Register(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public string Login(LoginDto dto)
        {
            // Hardcoded admin check
            if (dto.Email == "admin@mail.com" && dto.Password == "admin123")
            {
                return GenerateToken(0, "admin@mail.com", "Admin"); //  id=0 for hardcoded admin
            }

            var user = _db.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new Exception("Invalid credentials");

            return GenerateToken(user.Id, user.Email, "User"); // passing real user ID
        }

        //  Added userId parameter to claims
        private string GenerateToken(int userId, string email, string role)
        {
            var jwt = _config.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()), // ✅ THIS was missing!
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