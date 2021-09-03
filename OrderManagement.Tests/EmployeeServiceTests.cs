using Microsoft.EntityFrameworkCore;
using Moq;
using orderManagement.Core.Entities.Employees;
using orderManagement.Core.Interface;
using orderManagement.Dtos.Employees;
using orderManagement.Infrastructure.Data;
using orderManagement.Infrastructure.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OrderManagement.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Employee _employee = new()
        {
            Id = 1,
            Name = "axiaobug",
            Address = "Test1",
            BirthDate = new DateTime(1986, 2, 15),
            WeChat = "axiaobug",
            HireDate = new DateTime(2018, 9, 1),
            SuperAccount = "1111",
            AnnualLeave = 0,
            SickLeave = 0,
            PayRate = 25,
            DepartmentId = 1,
        };
        private readonly EmployeeCreateDto _createDto = new()
        {
            Name = "Test",
            Address = "222222",
            BirthDate = new DateTime(1986, 2, 15),
            WeChat = "aaaaa",
            HireDate = new DateTime(2018, 9, 1),
            SuperAccount = "1111",
            AnnualLeave = 0,
            SickLeave = 0,
            PayRate = 50,
            DepartmentId = 1,
        };

        private readonly Mock<IUnitOfWork> _mockIUnitOfWork;
        private readonly IEmployeeService _employeeService;

        public EmployeeServiceTests(DbContextOptions<StoreDbContext> contextOptions)
        {
            _mockIUnitOfWork = new Mock<IUnitOfWork>();
            var context = new Mock<StoreDbContext>(contextOptions);

            _employeeService = new EmployeeService(_mockIUnitOfWork.Object, context.Object);
        }

        [Fact]
        public async Task GetEmployeeById_NameShouldBe_OK()
        {
            _mockIUnitOfWork.Setup(repo => repo.Repository<Employee>().GetByIdAsync(1).Result).Returns(_employee);
            
            var response = await _employeeService.GetEmployeeById(1);
            Assert.Equal("axiaobug",response.Name);
        }

        [Fact]
        public async Task GetEmployeeById_WhenIdLessThen1_NotFound()
        {
            _mockIUnitOfWork.Setup(repo => repo.Repository<Employee>().GetByIdAsync(1).Result).Returns((Employee)null);
            var response = await _employeeService.GetEmployeeById(-1);
            Assert.Null(response);
        }

        [Fact]
        public async Task CreateEmployee_Should_OK()
        {
            _mockIUnitOfWork.Setup(x => x.Repository<Employee>().Add(_employee));
            _mockIUnitOfWork.Setup(x=>x.Complete().Result).Returns((bool res)=>true);
            var response =await _employeeService.CreateEmployeeAsync(_createDto);
            Assert.Equal("Test",response.Name);
        }

        [Fact]
        public async Task UpdateEmployee_Should_OK()
        {

            _employee.Name = "Jessi";
            _mockIUnitOfWork.Setup(x => x.Repository<Employee>().Update(_employee));
            _mockIUnitOfWork.Setup(x => x.Complete().Result).Returns((bool res) => true);
            _mockIUnitOfWork.Setup(x => x.Repository<Employee>().GetByIdAsync(1).Result).Returns(_employee);
            var response = await _employeeService.UpdateEmployeeAsync(_employee);
            Assert.Equal("Jessi",response.Name);
        }

        [Fact]
        public async Task UpdateEmployee_EmptyEmployee_ShouldFailed()
        {
            _mockIUnitOfWork.Setup(x => x.Repository<Employee>().Update(null));
            var response = await _employeeService.UpdateEmployeeAsync(null);
            Assert.Null(response);

        }

        [Fact]
        public async Task DeleteEmployeeByIdAsync_InPutEmployee_ShouldOK()
        {

            _mockIUnitOfWork.Setup(x => x.Repository<Employee>().Delete(_employee));
            var response = await _employeeService.DeleteEmployeeByIdAsync(_employee);
            Assert.True(response);
        }

        [Fact]
        public async Task DeleteEmployeeByIdAsync_InEmptyEmployee_ShouldFailed()
        {
            _mockIUnitOfWork.Setup(x => x.Repository<Employee>().Delete(null));
            var result = await _employeeService.DeleteEmployeeByIdAsync(null);
            Assert.False(result);
        }
    }

    
}
