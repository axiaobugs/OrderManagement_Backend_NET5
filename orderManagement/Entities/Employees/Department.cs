using System.ComponentModel.DataAnnotations;

namespace orderManagement.Entities.Employees
{
    public class Department:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public Employee[] Employees { get; set; }
    }
}