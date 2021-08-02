using orderManagement.Entities.Orders;
using orderManagement.Entities.Payment;

namespace orderManagement.Entities.Customers
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; } = "null";
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string DeliveryTo { get; set; }
        public Order[] Orders { get; set; }

    }
}