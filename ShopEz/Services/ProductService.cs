using ShopEz.Models;
using ShopEz.DTOs;
using Microsoft.EntityFrameworkCore;
using ShopEz.Repositories;

namespace ShopEz.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            var data = await _repo.GetById(id);
            if (data == null) throw new Exception("Product not found");
            return data;
        }

        public async Task<Product> Add(ProductDto dto)
        {
            var p = new Product
            {
                Name = dto.Name,
                Desc = dto.Desc,
                Price = dto.Price,
                Stock = dto.Stock
            };

            await _repo.Add(p);
            return p;
        }

        public async Task<Product> Update(int id, ProductDto dto)
        {
            var p = await _repo.GetById(id);
            if (p == null) throw new Exception("Product not found");

            p.Name = dto.Name;
            p.Desc = dto.Desc;
            p.Price = dto.Price;
            p.Stock = dto.Stock;

            await _repo.Update(p);
            return p;
        }

        public async Task<bool> Delete(int id)
        {
            var p = await _repo.GetById(id);
            if (p == null) throw new Exception("Product not found");

            await _repo.Delete(p);
            return true;
        }
    }
}