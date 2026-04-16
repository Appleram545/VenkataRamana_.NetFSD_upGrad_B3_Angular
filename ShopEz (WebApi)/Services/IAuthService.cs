using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopEz.Models;
using ShopEz.DTOs;

namespace ShopEz.Services
{
    public interface IAuthService
    {
        User Register(User user);
        string Login(LoginDto dto);
    }
}