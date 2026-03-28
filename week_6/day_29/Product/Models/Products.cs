using System.ComponentModel.DataAnnotations;
namespace Product.Models
{
    public class ProductItems
    {
        [Required(ErrorMessage ="Produit Id is Mandatory")]
        public int? productId{get;set;}

        [Required(ErrorMessage = "Product Name is Mandatory")]
        [StringLength (15,MinimumLength=5 , ErrorMessage ="Can not Exceed 15 Characters and below 5")]
        public string name{get;set;}

        [Required(ErrorMessage = "Price is Mandatory")]
        public double ?price{get;set;}

        [Required(ErrorMessage = "Category is Mandatory")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Can not Exceed 15 Characters and below 5")]
        public string category{get;set;}
    }
}