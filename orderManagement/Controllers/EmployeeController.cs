using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using orderManagement.Core.Entities.Employees;
using orderManagement.Core.Interface;
using orderManagement.Dtos.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;
using orderManagement.Core.Specifications;
using orderManagement.Errors;
using orderManagement.Helpers;

namespace orderManagement.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeController:BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Employee> _employeeRepo;


        public EmployeeController(IEmployeeService employeeService,IMapper mapper,IUnitOfWork unitOfWork,IGenericRepository<Employee> employeeRepo)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _employeeRepo = employeeRepo;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var response = await _employeeService.CreateEmployeeAsync(employeeCreateDto);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<EmployeeReturnDto>>> GetAllEmployee([FromQuery]EmployeeSpecificationParams employeeSpecificationParams)
        {
            var spec = new EmployeeWithSpecification(employeeSpecificationParams);
            var countSpec = new EmployeeWithFiltersForCountSpec(employeeSpecificationParams);
            var totalItems = await _employeeRepo.CountAsync(countSpec);
            var employees = await _employeeRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<EmployeeReturnDto>>(employees);
            return Ok(new Pagination<EmployeeReturnDto>(employeeSpecificationParams.PageIndex,employeeSpecificationParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReturnDto>> GetEmployeeById(int id)
        {
            if (id < 0) return BadRequest();
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee is null) return NotFound();
            return Ok(_mapper.Map<EmployeeReturnDto>(employee));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployeeById([FromBody] EmployeeReturnDto employeeReturnDto)
        {
            
            if (employeeReturnDto == null)
            {
                return NotFound();
            }
                
            var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(employeeReturnDto.Id);
            _mapper.Map(employeeReturnDto, employee);
            _unitOfWork.Repository<Employee>().Update(employee);
            if (await _unitOfWork.Complete())
            {
                return NoContent();
            }

            return BadRequest("Fail to update employee");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeById(int id)
        {       
            var result = await _employeeService.DeleteEmployeeByIdAsync(id);
            return result?Ok(new ApiResponse(200)):BadRequest(new ApiResponse(400, "problem delete employee"));
        }

    }
}