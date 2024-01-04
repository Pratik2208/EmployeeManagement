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
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DepartmentController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment([FromBody] AddDepartmentRequest request)
        {

            Department dept = _mapper.Map<Department>(request);

            var department = await _context.Departments.AddAsync(dept);
            await _context.SaveChangesAsync();

            return Ok(dept);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartmentById(int id)
        {
            Department dept = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (dept == null)
            {
                return NotFound("Department not found with Given Id...");
            }

            // returning the department

            return Ok(_mapper.Map<GetDepartmentResponse>(dept));
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(_mapper.Map<GetDepartmentResponse[]>(departments));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartmentById(int id)
        {
            Department dept = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (dept == null)
            {
                return NotFound("Department not found with Given Id...");
            }

            // deleting the department
            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return Ok(dept);
        }

        [HttpGet("WithEmployess")]
        public async Task<ActionResult> GetDepartmentWithAllEmployees(int departmentId)
        {
            Department dept = await _context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (dept == null)
            {
                return NotFound("Department not found with Given Id...");
            }

            else
            {
                var result =
                    await _context.Departments
                    .Where(deps => deps.DepartmentId == departmentId)
                    .Select(department => new
                    {
                        DepartmentName = department.DepartmentName,
                        EmployeeNames = department.Employees.Select(e => e.EmployeeName)
                    })
                    .FirstOrDefaultAsync();

                return Ok(result);
            }

        }

        [HttpGet("AllDepartmentsWithEmployees")]
        public async Task<ActionResult> GetAllDepartmentWithAllEmployees()
        {
            var result =
                await _context.Departments
                .Select(department => new
                {
                    DepartmentName = department.DepartmentName,
                    EmployeeNames =  department.Employees.Select(e => e.EmployeeName)
                })
                .ToListAsync();

            return Ok(result);
                
        }
    }
}
