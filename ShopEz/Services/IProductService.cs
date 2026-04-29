using ShopEz.Models;
using ShopEz.Controllers;
using ShopEz.Services;
using ShopEz.Repositories;
using ShopEz.DTOs;

namespace ShopEz.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(ProductDto dto);
        Task<Product> Update(int id, ProductDto dto);
        Task<bool> Delete(int id);
    }
}