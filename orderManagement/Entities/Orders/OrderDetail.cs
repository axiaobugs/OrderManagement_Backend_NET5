namespace orderManagement.Entities.Orders
{
    public class OrderDetail:BaseEntity
    {
        // 1: Internal Drawer 2: External Drawer
        public int DrawerType { get; set; }
        public int DrawerQuantity { get; set; }
        public Category Category { get; set; }
        public int AdditionalDoor { get; set; }
        public Order Order{ get; set; }
    }
}