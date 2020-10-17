using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class Phone : BaseEntity
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must have min length of {2} characters and max length of {1} characters", MinimumLength = 8)]
        public string Number { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}