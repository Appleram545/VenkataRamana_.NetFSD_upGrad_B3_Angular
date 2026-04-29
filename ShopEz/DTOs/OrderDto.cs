
using System.ComponentModel.DataAnnotations;

namespace ShopEz.DTOs{
public class OrderDto
{
                [Required(ErrorMessage = "Items are required")]
                [MinLength(1, ErrorMessage = "At least one item is required")]
                public List<OrderItemDto> Items { get; set; }
        }
}