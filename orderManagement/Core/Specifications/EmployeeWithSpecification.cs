using orderManagement.Core.Entities.Employees;

namespace orderManagement.Core.Specifications
{
    public class EmployeeWithSpecification:BaseSpecification<Employee>
    {
        public EmployeeWithSpecification(EmployeeSpecificationParams employeeSpecificationParams)
        :base(x=>
            (string.IsNullOrEmpty(employeeSpecificationParams.Search)||x.Name.ToLower().Contains(employeeSpecificationParams.Search))
            )
        {
            AddInclude(x => x.Department);
            AddOrderBy(x=>x.Department.Name);
            ApplyPaging(employeeSpecificationParams.PageSize*(employeeSpecificationParams.PageIndex-1),employeeSpecificationParams.PageSize);
        }

        public EmployeeWithSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x=>x.Department);
        }
    }


}