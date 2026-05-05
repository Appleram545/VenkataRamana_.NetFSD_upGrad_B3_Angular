using Microsoft.EntityFrameworkCore;
using ShopEz.Models;
using ShopEz.DTOs;
using ShopEz.Data;
using ShopEz.Repositories;

namespace ShopEz.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;

        public OrderService(AppDbContext db)
        {
            _db = db;
        }

        // Now saves userId with the order
        public async Task<Order> Create(OrderDto dto, int userId)
        {
            if (dto.Items == null || dto.Items.Count == 0)
                throw new Exception("Cart empty");

            var list = new List<OrderItem>();

            foreach (var i in dto.Items)
            {
                if (i.Qty <= 0)
                    throw new Exception("Qty must be > 0");

                var p = await _db.Products.FindAsync(i.ProductId);

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
                UserId = userId,   //  save who placed the order
                Date = DateTime.Now,
                Total = total,
                Items = list
            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return order;
        }

        // Admin can  get all orders
        public async Task<List<Order>> GetAll()
        {
            return await _db.Orders.Include(x => x.Items).ToListAsync();
        }

        //  Customer Can get only their own orders
        public async Task<List<Order>> GetByUserId(int userId)
        {
            return await _db.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            var o = await _db.Orders.Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (o == null) throw new Exception("Order not found");

            return o;
        }
    }
}