
using System.ComponentModel.DataAnnotations;

namespace ShopEz.DTOs
{
    public class OrderItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, 100, ErrorMessage = "Qty must be > 0")]
        public int Qty { get; set; }
    }
}