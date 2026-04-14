
using System.ComponentModel.DataAnnotations;
using ShopEz.Models;

namespace ShopEz.Models
{


    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}