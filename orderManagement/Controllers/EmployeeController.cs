using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using orderManagement.Core.Entities.Employees;
using orderManagement.Core.Interface;
using orderManagement.Dtos.Employees;

namespace orderManagement.Controllers
{

    /// <summary>
    ///
    ///
    /// TODO: need 
    /// </summary>
    public class EmployeeController:BaseController
    {
        private readonly IEmployeeService _employeeService;


        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var response = await _employeeService.CreateEmployeeAsync(employeeCreateDto);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            if (id < 0) return BadRequest();
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee is null) return NotFound();
            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployeeById([FromBody] Employee employee)
        {
            if (employee == null) return NotFound();
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
            if (updatedEmployee == null) return BadRequest();
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeById(Employee employee)
        {
            var deleteEmployeeById = await _employeeService.DeleteEmployeeByIdAsync(employee);
            if (!deleteEmployeeById) return NotFound();
            return Ok();
        }

    }
}