using Microsoft.EntityFrameworkCore;
using ShopEz.Models;
using ShopEz.DTOs;
using ShopEz.Data;
using ShopEz.Repositories;


namespace ShopEz.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext db;

        public OrderService(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Order> Create(OrderDto dto)
        {
            if (dto.Items == null || dto.Items.Count == 0)
                throw new Exception("Cart empty");

            var list = new List<OrderItem>();

            foreach (var i in dto.Items)
            {
                if (i.Qty <= 0)
                    throw new Exception("Qty must be > 0");

                var p = await db.Products.FindAsync(i.ProductId);

                if (p == null)
                    throw new Exception("Product not found");

                if (p.Stock < i.Qty)
                    throw new Exception("Not enough stock");

                p.Stock -= i.Qty;

                list.Add(new OrderItem
                {
                    ProductId = p.Id,
                    Qty = i.Qty,
                    Price = p.Price
                });
            }

            var total = list.Sum(x => x.Price * x.Qty);

            var order = new Order
            {
                Date = DateTime.Now,
                Total = total,
                Items = list
            };

            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            return await db.Orders.Include(x => x.Items).ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            var o = await db.Orders.Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (o == null) throw new Exception("Order not found");

            return o;
        }
    }
}