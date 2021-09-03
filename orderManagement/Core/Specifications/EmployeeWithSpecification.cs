using orderManagement.Core.Entities.Employees;

namespace orderManagement.Core.Specifications
{
    public class EmployeeWithSpecification:BaseSpecification<Employee>
    {
        public EmployeeWithSpecification(EmployeeSpecificationParams employeeSpecificationParams)
        :base(x=>
            (string.IsNullOrEmpty(employeeSpecificationParams.Search)||x.Name.ToLower().Contains(employeeSpecificationParams.Search))&&
            (!employeeSpecificationParams.DepartmentId.HasValue||x.DepartmentId==employeeSpecificationParams.DepartmentId)
            )
        {
            AddInclude(x => x.Department);
            AddOrderBy(x=>x.Department.Name);
            ApplyPaging(employeeSpecificationParams.PageSize*(employeeSpecificationParams.PageIndex-1),employeeSpecificationParams.PageSize);
            
            if (!string.IsNullOrEmpty(employeeSpecificationParams.Sort))
            {
                switch (employeeSpecificationParams.Sort)
                {
                    case "payRateAsc":
                        AddOrderBy(p => p.PayRate);
                        break;
                    case "payRateDesc":
                        AddOrderByDescending(p => p.PayRate);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public EmployeeWithSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x=>x.Department);
        }
    }


}