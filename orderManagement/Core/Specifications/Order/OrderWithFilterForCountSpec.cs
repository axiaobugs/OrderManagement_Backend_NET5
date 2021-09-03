namespace orderManagement.Core.Specifications.Order
{
    public class OrderWithFilterForCountSpec:BaseSpecification<orderManagement.Entities.Orders.Order>
    {
        public OrderWithFilterForCountSpec(OrderSpecificationParams orderSpecificationParams)
            : base(x =>
                (string.IsNullOrEmpty(orderSpecificationParams.Search) || x.OrderNumber.Contains(orderSpecificationParams.Search)) &&
                (!orderSpecificationParams.OrderStatus.HasValue || x.OrderStatus == orderSpecificationParams.OrderStatus)
            )
        {
        }
    }
}