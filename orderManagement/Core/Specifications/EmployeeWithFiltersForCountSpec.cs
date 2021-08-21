using orderManagement.Core.Entities.Employees;

namespace orderManagement.Core.Specifications
{
    public class EmployeeWithFiltersForCountSpec:BaseSpecification<Employee>
    {
        public EmployeeWithFiltersForCountSpec(EmployeeSpecificationParams employeeSpecificationParams)
        :base(x=>
            (string.IsNullOrEmpty(employeeSpecificationParams.Search)||x.Name.ToLower().Contains(employeeSpecificationParams.Search))
            )
        {
        }
    }
}