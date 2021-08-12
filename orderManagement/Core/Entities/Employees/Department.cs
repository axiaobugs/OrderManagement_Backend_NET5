using System.ComponentModel.DataAnnotations;
using orderManagement.Core.Entities.Employees;

namespace orderManagement.Entities.Employees
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public Employee[] Employees { get; set; }
    }
}