using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using orderManagement.Entities.Orders;

namespace orderManagement.Entities.Orders
{
    [Table("order_requirement_base")]
    public class OrderRequirementsBase: BaseEntity
    {
        [Required]
        public Materials Material { get; set; } = Materials.CheckPlat;
        [Required]
        public Thickness Thick { get; set; } = Thickness.MiddleThick;
        [Required]
        public string Paint { get; set; } = "null";
        public DateTimeOffset FitDate { get; set; }
        [Required]
        public DateTimeOffset DueDate { get; set; }
        [Required]
        public string[] OrderFiles { get; set; }

        public string[] Note { get; set; }

        public Order Order { get; set; }
    }
}