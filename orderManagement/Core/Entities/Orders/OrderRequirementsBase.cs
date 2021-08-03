using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace orderManagement.Entities.Orders
{
    [Table("order_requirement_base")]
    public class OrderRequirementsBase: BaseEntity
    {
        public OrderRequirementsBase()
        {
        }

        public OrderRequirementsBase(Materials material, Thickness thick, string paint, DateTimeOffset? fitDate, DateTimeOffset dueDate, List<OrderUploadFile> uploadFiles, Order order, int orderId)
        {
            Material = material;
            Thick = thick;
            Paint = paint;
            FitDate = fitDate;
            DueDate = dueDate;
            Order = order;
            OrderId = orderId;
            UploadFiles = uploadFiles;
        }

        public Materials Material { get; set; }
        public Thickness Thick { get; set; }
        public string Paint { get; set; }
        public DateTimeOffset? FitDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public List<OrderUploadFile> UploadFiles { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}