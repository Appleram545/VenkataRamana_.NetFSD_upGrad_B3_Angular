
using System.ComponentModel.DataAnnotations;
using ShopEz.Models;
using System.Text.Json.Serialization;

namespace ShopEz.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 500 characters")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(0, 1000, ErrorMessage = "Stock must be between 0 and 1000")]
        public int Stock { get; set; }

        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }
    }
}