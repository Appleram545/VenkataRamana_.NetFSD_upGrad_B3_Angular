
using System.ComponentModel.DataAnnotations;

namespace ShopEz.DTOs{
public class OrderDto
{
        [Required(ErrorMessage = "Items required")]
        public List<OrderItemDto> Items { get; set; }
}
}