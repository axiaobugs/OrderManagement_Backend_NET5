using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using orderManagement.Entities.Orders;

namespace orderManagement.Entities.Employees
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string WeChat { get; set; }
        public DateTime HireDate { get; set; }
        public string SuperAccount { get; set; }
        public decimal AnnualLeave { get; set; }
        public decimal SickLeave { get; set; }
        public decimal PayRate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}