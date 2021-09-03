using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using orderManagement.Dtos.Employees;
using orderManagement.Entities;
using orderManagement.Entities.Employees;
using orderManagement.Entities.Orders;

namespace orderManagement.Core.Entities.Employees
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
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();


        public static Employee CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            return new Employee()
            {
                Name = employeeCreateDto.Name,
                Address = employeeCreateDto.Address,
                DepartmentId = employeeCreateDto.DepartmentId,
                PayRate = employeeCreateDto.PayRate,
                AnnualLeave = employeeCreateDto.AnnualLeave,
                SickLeave = employeeCreateDto.SickLeave,
                SuperAccount = employeeCreateDto.SuperAccount,
                BirthDate = employeeCreateDto.BirthDate,
                HireDate = employeeCreateDto.HireDate,
                WeChat = employeeCreateDto.WeChat
            };
        }
    }

    
}