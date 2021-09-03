
namespace orderManagement.Dtos.Order
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int DrawerType { get; set; }
        public int DrawerQuantity { get; set; }
        public int Category { get; set; }
        public int AdditionalDoor { get; set; }
    }
}