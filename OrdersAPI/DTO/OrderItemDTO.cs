namespace OrdersAPI.DTO
{
    public class OrderItemDTO
    {
        public string Product { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}