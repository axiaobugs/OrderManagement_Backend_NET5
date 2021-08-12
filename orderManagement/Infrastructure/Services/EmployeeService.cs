using orderManagement.Core.Entities.Employees;
using orderManagement.Core.Interface;
using orderManagement.Dtos.Employees;
using System.Threading.Tasks;

namespace orderManagement.Infrastructure.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;


        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto == null) return null;

            var employee = new Employee(employeeCreateDto);
            _unitOfWork.Repository<Employee>().Add(employee);
            // save to db
            var result = await _unitOfWork.Complete();

            return result <1 ? null : employee;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            if (id < 0) return null;
            return await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null) return null;
            _unitOfWork.Repository<Employee>().Update(employee);
            var result = await _unitOfWork.Complete();
            return result < 1 ? null : employee;
        }

        public async Task<bool> DeleteEmployeeByIdAsync(Employee employee)
        {
            if (employee == null) return false;
            _unitOfWork.Repository<Employee>().Delete(employee);
            await _unitOfWork.Complete();
            return true;
        }
    }
}