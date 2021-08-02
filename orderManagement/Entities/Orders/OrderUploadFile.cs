namespace orderManagement.Entities.Orders
{
    public class OrderUploadFile:BaseEntity
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public string FileUri { get; set; }
    }
}