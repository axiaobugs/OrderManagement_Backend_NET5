using orderManagement.Dtos.Employees;
using System.Collections.Generic;

namespace orderManagement.Dtos.Order
{
    public class OrderReturnDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int OrderCode { get; set; }
        public decimal Price { get; set; }
        public int OrderStatus { get; set; }
        public OrderRequirementBaseDto OrderRequirementsBase { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public int CustomerId { get; set; }
        public List<EmployeeReturnDto> Employees { get; set; }
    }
}