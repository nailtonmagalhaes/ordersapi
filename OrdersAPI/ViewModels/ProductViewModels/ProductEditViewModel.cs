using System.ComponentModel.DataAnnotations;

namespace OrdersAPI.ViewModels.ProductViewModels
{
    public class ProductEditViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must have min length of {2} characters and max length of {1} characters", MinimumLength = 3)]
        public string Description { get; set; }
        [Range(0F, double.MaxValue, ErrorMessage = "The Unit Price must be greater than or equal zero")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The CategoryID must be greater than zero")]
        public int CategoryID { get; set; }
    }
}