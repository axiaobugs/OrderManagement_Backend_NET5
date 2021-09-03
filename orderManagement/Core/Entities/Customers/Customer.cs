using orderManagement.Entities.Orders;
using orderManagement.Entities.Payment;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace orderManagement.Entities.Customers
{
    public class Customer:BaseEntity
    {
        public Customer()
        {
        }

        public Customer(string name, 
            string address, 
            string companyName, 
            string contactNumber, 
            string email, 
            PaymentStatus paymentStatus, 
            PaymentMethod paymentMethod, 
            string deliveryTo
            )
        {
            Name = name;
            Address = address;
            CompanyName = companyName;
            ContactNumber = contactNumber;
            Email = email;
            PaymentStatus = paymentStatus;
            PaymentMethod = paymentMethod;
            DeliveryTo = deliveryTo;
        }


        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string DeliveryTo { get; set; }
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

    }
}