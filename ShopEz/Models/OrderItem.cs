
using System.ComponentModel.DataAnnotations;
using ShopEz.Models;
using System.Text.Json.Serialization;

namespace ShopEz.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "OrderId is required")]
        public int OrderId { get; set; } // Foreign Key

        [Required(ErrorMessage = "ProductId is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
    }
}