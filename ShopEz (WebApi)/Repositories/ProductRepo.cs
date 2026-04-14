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
        private readonly AppDbContext db;

        public ProductRepo(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<List<Product>> GetAll()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task Add(Product p)
        {
            db.Products.Add(p);
            await db.SaveChangesAsync();
        }

        public async Task Update(Product p)
        {
            db.Products.Update(p);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Product p)
        {
            db.Products.Remove(p);
            await db.SaveChangesAsync();
        }
    }
}