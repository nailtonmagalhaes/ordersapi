using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdersAPI.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be greater than or equal to {2} and less than or equal {1}", MinimumLength = 3)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}

