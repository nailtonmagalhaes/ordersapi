using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must have min length of {2} characters and max length of {1} characters", MinimumLength = 3)]
        public string Description { get; set; }

        [Range(0F, double.MaxValue, ErrorMessage = "The Unit Price must be greater than or equal zero")]
        public decimal UnitPrice { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}