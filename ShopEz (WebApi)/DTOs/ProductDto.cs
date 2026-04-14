
using System.ComponentModel.DataAnnotations;


namespace ShopEz.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be > 0")]
        public decimal Price { get; set; }

        [Range(0, 1000, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }
    }
}