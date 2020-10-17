using System.Collections.Generic;

namespace OrdersAPI.DTO
{
    public class OrderDTO
    {
        public string Customer { get; set; }
        public string Document { get; set; }
        public string PostalCode { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public string FU { get; set; }
        public string State { get; set; }
        public decimal ShippingCost { get; set; }
    }
}