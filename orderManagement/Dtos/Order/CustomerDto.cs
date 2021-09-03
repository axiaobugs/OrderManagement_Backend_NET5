using System.Collections.Generic;
using orderManagement.Entities.Payment;

namespace orderManagement.Dtos.Order
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int PaymentStatus { get; set; }
        public int PaymentMethod { get; set; }
        public string DeliveryTo { get; set; }
        public ICollection<OrderReturnDto> Orders { get; set; }
    }
}