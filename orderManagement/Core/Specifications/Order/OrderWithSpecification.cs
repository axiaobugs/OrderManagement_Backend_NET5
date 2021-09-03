

namespace orderManagement.Core.Specifications.Order
{
    public class OrderWithSpecification:BaseSpecification<orderManagement.Entities.Orders.Order>
    {
        public OrderWithSpecification(OrderSpecificationParams orderSpecificationParams)
        :base(x=>
            (string.IsNullOrEmpty(orderSpecificationParams.Search) || x.OrderNumber.Contains(orderSpecificationParams.Search))&&
            (!orderSpecificationParams.OrderStatus.HasValue||x.OrderStatus==orderSpecificationParams.OrderStatus)
            )
        {
            AddInclude(x=>x.Customer);
            AddInclude(x=>x.Employees);
            AddInclude(x=>x.RequirementBase);
            AddInclude(x=>x.OrderDetails);
            ApplyPaging(orderSpecificationParams.PageSize * (orderSpecificationParams.PageIndex - 1), orderSpecificationParams.PageSize);

            if (!string.IsNullOrEmpty(orderSpecificationParams.Sort))
            {
                switch (orderSpecificationParams.Sort)
                {
                    case "dueDateAsc":
                        AddOrderBy(o => o.RequirementBase.DueDate);
                        break;
                    case "dueDateDesc":
                        AddOrderByDescending(o => o.RequirementBase.DueDate);
                        break;
                    default:
                        AddOrderBy(o => o.OrderNumber);
                        break;
                }
            }


        }
    }
}