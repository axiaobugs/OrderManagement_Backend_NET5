using System;
using System.Collections.Generic;
using orderManagement.Dtos.Employees;
using orderManagement.Entities;
using orderManagement.Entities.Employees;
using orderManagement.Entities.Orders;

namespace orderManagement.Core.Entities.Employees
{
    public class Employee:BaseEntity
    {
        public Employee()
        {
        }

        public Employee(EmployeeCreateDto createDto)
        {
            // 
            Name = createDto.Name;
            Address = createDto.Address;
            BirthDate = createDto.BirthDate;
            WeChat = createDto.WeChat;
            HireDate = createDto.HireDate;
            SuperAccount = createDto.SuperAccount;
            AnnualLeave = createDto.AnnualLeave;
            SickLeave = createDto.SickLeave;
            PayRate = createDto.PayRate;
            DepartmentId = createDto.DepartmentId;
        }

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