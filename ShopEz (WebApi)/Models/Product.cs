
using System.ComponentModel.DataAnnotations;
using ShopEz.Models;
using System.Text.Json.Serialization;

namespace ShopEz.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Range(0, 1000)]
        public int Stock { get; set; }

        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }
    }
}