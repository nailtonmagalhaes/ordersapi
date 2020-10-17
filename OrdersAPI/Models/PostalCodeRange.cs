using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class PostalCodeRange : BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string Start { get; set; }

        [Required]
        [StringLength(15)]
        public string End { get; set; }

        [Range(0f, double.MaxValue, ErrorMessage = "The Price must be greater than or equal zero")]
        public decimal Price { get; set; }

        public int StateID { get; set; }

        [ForeignKey("StateID")]
        public State State { get; set; }
    }
}