using ShopEz.Models;
using ShopEz.Controllers;
using ShopEz.Services;
using ShopEz.Repositories;
using ShopEz.DTOs;

namespace ShopEz.Services
{
    public interface IOrderService
    {
        Task<Order> Create(OrderDto dto);
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
    }
}