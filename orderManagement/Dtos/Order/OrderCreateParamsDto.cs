namespace orderManagement.Dtos.Order
{
    public class OrderCreateParamsDto
    {
        public OrderCreateDto OrderCreateDto { get; set; }
        public OrderRequirementBaseDto OrderRequirementBaseDto { get; set; }
        public OrderDetailDto OrderDetailDto { get; set; }
    }
}