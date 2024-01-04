using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Requests;
using EmployeeManagement.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmployeeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(AddEmployeeRequest request)
        {
            // Checking if department is exist or not
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == request.DepartmentId);
        

            if(department == null)
            {
                return NotFound("Department Not exist...");
            }

            else
            {
                var empl = _mapper.Map<Employee>(request);
                var employee = await _context.Employees.AddAsync(empl);
                await _context.SaveChangesAsync();

                return Ok(empl);
            }
        }
    }
}
