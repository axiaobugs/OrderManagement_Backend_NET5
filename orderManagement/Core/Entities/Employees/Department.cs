using System.ComponentModel.DataAnnotations;

namespace orderManagement.Entities.Employees
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public Employee[] Employees { get; set; }
    }
}