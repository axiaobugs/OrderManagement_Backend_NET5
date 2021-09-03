namespace orderManagement.Dtos.Order
{
    public class OrderCreateDto
    {
        public string OrderNumber { get; set; }
        public int OrderCode { get; set; }
        public decimal Price { get; set; }
        public int OrderStatus { get; set; }
        public int CustomerId { get; set; }
    }
}