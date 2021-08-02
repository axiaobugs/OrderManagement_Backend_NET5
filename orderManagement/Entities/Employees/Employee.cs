using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace orderManagement.Entities.Employees
{
    public class Employee:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string WeChat { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public string SuperAccount { get; set; }
        [Required]
        public decimal AnnualLeave { get; set; }
        [Required]
        public decimal SickLeave { get; set; }
        [Required]
        public decimal PayRate { get; set; }
        public Department Department { get; set; }
    }
}