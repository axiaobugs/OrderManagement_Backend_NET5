using System;

namespace orderManagement.Dtos.Employees
{
    public class EmployeeCreateDto
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
        public int DepartmentId { get; set; }
    }
}