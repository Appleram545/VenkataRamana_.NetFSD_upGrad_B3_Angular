using ShopEz.Models;
using ShopEz.Controllers;
using ShopEz.Services;
using ShopEz.Repositories;
using ShopEz.DTOs;

namespace ShopEz.Services
{
    public interface IOrderService
    {
        Task<Order> Create(OrderDto dto, int userId); 
        Task<List<Order>> GetAll();
        Task<List<Order>> GetByUserId(int userId);     
        Task<Order> GetById(int id);
    }
}