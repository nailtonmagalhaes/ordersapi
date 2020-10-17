using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrdersAPI.CustomAttributes;

namespace OrdersAPI.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be greater than or equal to {2} and less than or equal {1}", MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be greater than or equal to {2} and less than or equal {1}", MinimumLength = 5)]
        public string Document { get; set; }

        public List<Order> Orders { get; set; }

        [MustHaveOneElement(ErrorMessage = "You must provide at least one Address")]
        public List<PostalAddress> Adresses { get; set; }

        [MustHaveOneElement(ErrorMessage = "You must provide at least one Phone")]
        public List<Phone> Phones { get; set; }
    }
}