using orderManagement.Entities.Customers;

namespace orderManagement.Entities.Orders
{
    public class Order:BaseEntity
    {
        public int OrderNumber { get; set; }
        public OrderCode OrderCode { get; set; }
        public OrderRequirementsBase RequirementBase { get; set; }
        public OrderDetail[] OrderDetails { get; set; }
        public decimal Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Customer Customer{ get; set; }

    }
}