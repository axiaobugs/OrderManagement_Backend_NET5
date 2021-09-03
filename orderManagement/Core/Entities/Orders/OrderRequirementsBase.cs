using Newtonsoft.Json;
using orderManagement.Dtos.Order;
using orderManagement.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using orderManagement.Entities;

namespace orderManagement.Core.Entities.Orders
{
    [Table("order_requirement_base")]
    public class OrderRequirementsBase:BaseEntity
    {

        public Materials Material { get; set; }
        public Thickness Thick { get; set; }
        public string Paint { get; set; }
        public DateTime? FitDate { get; set; }
        public DateTime DueDate { get; set; }
        [JsonIgnore]
        public List<OrderUploadFile> UploadFiles { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public static OrderRequirementsBase CreateOrderRequirementsBase(OrderRequirementBaseDto orderRequirementBaseDto)
        {
            return new OrderRequirementsBase()
            {
                Material = (Materials)orderRequirementBaseDto.Material,
                Thick = (Thickness)orderRequirementBaseDto.Thick,
                Paint = orderRequirementBaseDto.Paint,
                FitDate = orderRequirementBaseDto.FitDate,
                DueDate = orderRequirementBaseDto.DueDate,
            };
        }
    }
}