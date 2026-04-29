using Microsoft.EntityFrameworkCore;
using ShopEz.Models;
using ShopEz.Controllers;
using ShopEz.Services;
using ShopEz.Repositories;
namespace ShopEz.Repositories
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Add(Product p);
        Task Update(Product p);
        Task Delete(Product p);
    }
}