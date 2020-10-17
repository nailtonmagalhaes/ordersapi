using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrdersAPI.CustomAttributes;

namespace OrdersAPI.Models
{
    public class State : BaseEntity
    {
        [Required]
        [StringLength(2, ErrorMessage = "The {0} must have min length of {2} characters and max length of {1} characters", MinimumLength = 2)]
        public string FU { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must have min length of {2} characters and max length of {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [MustHaveOneElement(ErrorMessage="You must provide at least one Postal Address")]
        public List<PostalCodeRange> PostalCodeRanges { get; set; }
    }
}