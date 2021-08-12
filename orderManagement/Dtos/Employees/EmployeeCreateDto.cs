using System;

namespace orderManagement.Dtos.Employees
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; } = new DateTime(1990,1,1);
        public string WeChat { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string SuperAccount { get; set; }
        public decimal AnnualLeave { get; set; } = 0;
        public decimal SickLeave { get; set; } = 0;
        public decimal PayRate { get; set; } = 25;
        public int DepartmentId { get; set; }
    }
}