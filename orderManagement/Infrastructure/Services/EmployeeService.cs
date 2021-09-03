using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Entities.Employees;
using orderManagement.Core.Interface;
using orderManagement.Dtos.Employees;
using orderManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace orderManagement.Infrastructure.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StoreDbContext _context;


        public EmployeeService(IUnitOfWork unitOfWork,StoreDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto == null) return null;

            var employee = Employee.CreateEmployee(employeeCreateDto);
            _unitOfWork.Repository<Employee>().Add(employee);
            var result = await _unitOfWork.Complete();


            return result ? employee : null;
        }

        public async Task<IReadOnlyList<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(e=>e.Department).ToListAsync();
            // return await _unitOfWork.Repository<Employee>().ListAllAsync();
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
            await _unitOfWork.Complete();
            return await _unitOfWork.Complete() ? null : employee;
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        {
            var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
            if (employee == null) return false;
            _unitOfWork.Repository<Employee>().Delete(employee);           
            return await _unitOfWork.Complete();;
        }
    }
}