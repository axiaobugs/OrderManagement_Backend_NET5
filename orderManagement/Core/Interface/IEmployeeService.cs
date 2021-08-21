using System.Collections.Generic;
using System.Threading.Tasks;
using orderManagement.Core.Entities.Employees;
using orderManagement.Dtos.Employees;

namespace orderManagement.Core.Interface
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        Task<IReadOnlyList<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeByIdAsync(Employee employee);
    }
}