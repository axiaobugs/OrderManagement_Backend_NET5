using orderManagement.Core.Entities.Employees;
using orderManagement.Core.Entities.Orders;
using orderManagement.Dtos.Order;
using orderManagement.Entities.Customers;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace orderManagement.Entities.Orders
{
    public class Order:BaseEntity
    {

        public string OrderNumber { get; set; }
        public OrderCode OrderCode { get; set; }
        public OrderRequirementsBase RequirementBase { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public decimal Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        [JsonIgnore]
        public Customer Customer{ get; set; }
        public int CustomerId { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public static  Order CreateOrder(OrderCreateDto orderCreateDto)
        {
            return new Order()
            {
                OrderNumber = orderCreateDto.OrderNumber,
                OrderCode = (OrderCode)orderCreateDto.OrderCode,
                OrderStatus = (OrderStatus)orderCreateDto.OrderStatus,
                Price = orderCreateDto.Price,
                CustomerId = orderCreateDto.CustomerId,
            };
            
        }

    }
}