using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Interface;
using orderManagement.Entities.Employees;
using orderManagement.Infrastructure.Data;

namespace orderManagement.Controllers
{
    public class DepartmentController:BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StoreDbContext _dbContext;

        // TODO: service没有写,之后会完善.
        public DepartmentController(IUnitOfWork unitOfWork,StoreDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartment()
        {
            return Ok(await _dbContext.Departments.ToListAsync());
        }
    }
}