using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class PostalAddress : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must have min length of {2} characters and max length of {1} characters", MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; }

        [StringLength(30)]
        public string Neighborhood { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        public int StateID { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("StateID")]
        public State State { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}