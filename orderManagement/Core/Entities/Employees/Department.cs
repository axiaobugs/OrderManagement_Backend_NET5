using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using orderManagement.Core.Entities.Employees;

namespace orderManagement.Entities.Employees
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}