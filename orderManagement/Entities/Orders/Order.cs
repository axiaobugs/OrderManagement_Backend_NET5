using System.Collections;
using System.Collections.Generic;
using orderManagement.Entities.Customers;

namespace orderManagement.Entities.Orders
{
    public class Order:BaseEntity
    {
        public Order()
        {
        }

        public Order(string orderNumber, OrderCode orderCode, OrderRequirementsBase requirementBase, ICollection<OrderDetail> orderDetails, decimal price, OrderStatus orderStatus, Customer customer, int customerId)
        {
            OrderNumber = orderNumber;
            OrderCode = orderCode;
            RequirementBase = requirementBase;
            OrderDetails = orderDetails;
            Price = price;
            OrderStatus = orderStatus;
            Customer = customer;
            CustomerId = customerId;
        }

        public string OrderNumber { get; set; }
        public OrderCode OrderCode { get; set; }
        public OrderRequirementsBase RequirementBase { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public decimal Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Customer Customer{ get; set; }
        public int CustomerId { get; set; }

    }
}