using System.ComponentModel.DataAnnotations;
using ShopEz.Models;

namespace ShopEz.Models
{


    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0.01, 1000000, ErrorMessage = "Total must be greater than 0")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Order must contain at least one item")]
        [MinLength(1, ErrorMessage = "At least one order item is required")]
        public List<OrderItem> Items { get; set; }
    }
}