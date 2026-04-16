
using System.ComponentModel.DataAnnotations;

namespace ShopEz.DTOs
{
    public class OrderItemDto
    {
        [Required(ErrorMessage = "ProductId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductId must be greater than 0")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Qty { get; set; }
    }
}