namespace orderManagement.Entities.Orders
{
    public class OrderDetail:BaseEntity
    {
        public OrderDetail()
        {
        }

        public OrderDetail(int drawerType, int drawerQuantity, Category category, int additionalDoor, Order order, int orderId)
        {
            DrawerType = drawerType;
            DrawerQuantity = drawerQuantity;
            Category = category;
            AdditionalDoor = additionalDoor;
            Order = order;
            OrderId = orderId;
        }

        // 1: Internal Drawer 2: External Drawer
        public int DrawerType { get; set; }
        public int DrawerQuantity { get; set; }
        public Category Category { get; set; }
        public int AdditionalDoor { get; set; }
        public Order Order{ get; set; }
        public int OrderId { get; set; }
    }
}