using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class OrderItem : BaseEntity
    {
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity must be greater zero")]
        public int Quantity { get; set; }

        [Range(0f, double.MaxValue, ErrorMessage = "The Total Price must be greater than or equal zero")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The ProductID must be greater than zero")]
        public int ProductID { get; set; }

        public int OrderID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}