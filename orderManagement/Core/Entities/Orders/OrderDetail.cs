

using Newtonsoft.Json;
using orderManagement.Dtos.Order;

namespace orderManagement.Entities.Orders
{
    public class OrderDetail:BaseEntity
    {

        // 1: Internal Drawer 2: External Drawer
        public int DrawerType { get; set; }
        public int DrawerQuantity { get; set; }
        public Category Category { get; set; }
        public int AdditionalDoor { get; set; }
        [JsonIgnore]
        public Order Order{ get; set; }
        public int OrderId { get; set; }

        public static OrderDetail CreateOrderDetail(OrderDetailDto orderDetailDto)
        {
            return new OrderDetail()
            {
                DrawerQuantity = orderDetailDto.DrawerQuantity,
                DrawerType = orderDetailDto.DrawerType,
                Category = (Category)orderDetailDto.Category,
                AdditionalDoor = orderDetailDto.AdditionalDoor,

            };
        }

    }
}