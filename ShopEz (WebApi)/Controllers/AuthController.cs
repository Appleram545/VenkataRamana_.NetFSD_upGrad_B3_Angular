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
        private readonly IAuthService authService;

        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var result = authService.Register(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            try
            {
                var token = authService.Login(dto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}