using EmployeeManagement.API.Data;
using EmployeeManagement.API.DTOs;
using EmployeeManagement.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notification;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly NotificationService.NotificationServiceClient _client;

        public EmployeeController(AppDbContext context, NotificationService.NotificationServiceClient client)
        {
            _context = context;
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();
            await _client.SendWelcomeAsync(new NotificationRequest
            {
                Name = employee.Name,
                Email = employee.Email
            });
            return Ok(employee.Id);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Projects)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Salary = e.Salary,
                    Department = e.Department!.DepartmentName,
                    Projects = e.Projects
                                .Select(p => p.ProjectName)
                                .ToList()
                })
                .ToListAsync();

            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Projects)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDto dto)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            employee.Name = dto.Name;
            employee.Email = dto.Email;
            employee.Salary = dto.Salary;
            employee.DepartmentId = dto.DepartmentId;

            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
                return NotFound();

            _context.Employees.Remove(emp);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

