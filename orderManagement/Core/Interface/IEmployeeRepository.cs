using System.Collections.Generic;
using System.Threading.Tasks;
using orderManagement.Entities.Employees;

namespace orderManagement.Core.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IReadOnlyList<Employee>> GetEmployeesAsync();

    }
}