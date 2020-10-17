using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrdersAPI.CustomAttributes;

namespace OrdersAPI.Models
{
    public class Order : BaseEntity
    {
        [Required]
        [DataType("datetime")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must have min length of {2} characters and max length of {1} characters", MinimumLength = 5)]
        public string Number { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "The Price must be greater than zero")]
        public decimal TotalPrice { get; set; }
        public decimal ShippingCost { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The CustomerID must be grater than 1")]
        public int CustomerID { get; set; }

        [MustHaveOneElement(ErrorMessage = "The Order must have at least one item")]
        public List<OrderItem> Items { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}