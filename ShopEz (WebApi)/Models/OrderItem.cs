
using System.ComponentModel.DataAnnotations;
using ShopEz.Models;
using System.Text.Json.Serialization;

namespace ShopEz.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; } //  foreign key

        [Required]
        public int ProductId { get; set; }

        [Range(1, 100)]
        public int Qty { get; set; }

        public decimal Price { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
    }
}