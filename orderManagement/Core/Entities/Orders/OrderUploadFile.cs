using orderManagement.Core.Entities.Orders;

namespace orderManagement.Entities.Orders
{
    public class OrderUploadFile:BaseEntity
    {
        public OrderRequirementsBase OrderRequirementsBase { get; set; }
        public int OrderId { get; set; }
        public string FileUri { get; set; }
    }
}