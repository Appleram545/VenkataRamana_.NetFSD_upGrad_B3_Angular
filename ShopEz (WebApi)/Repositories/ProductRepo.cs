using Microsoft.EntityFrameworkCore;
using ShopEz.Models;
using ShopEz.Controllers;
using ShopEz.Services;
using ShopEz.Repositories;
using ShopEz.Data;

namespace ShopEz.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _db;

        public ProductRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task Add(Product p)
        {
            _db.Products.Add(p);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Product p)
        {
            _db.Products.Update(p);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Product p)
        {
            _db.Products.Remove(p);
            await _db.SaveChangesAsync();
        }
    }
}