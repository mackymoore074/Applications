using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using ClassLibrary.DtoModels.Employee;
using ClassLibrary;

namespace TheWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ClassDBContext _context;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ClassDBContext context, ILogger<EmployeeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            try
            {
                var employees = await _context.Employees
                    .Select(e => new EmployeeDto
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Email = e.Email,
                        DateCreated = e.DateCreated,
                        AdminName = e.Admin.LastName, // Assuming you have a navigation property to Admin
                        DepartmentNames = e.Departments.Select(d => d.Name).ToList() // Assuming you have a navigation property to Department
                    })
                    .ToListAsync();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in GetEmployees", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees
                    .Include(e => e.Admin)  // Load the admin details
                    .Include(e => e.Departments) // Load the department details
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                    return NotFound($"Employee with ID {id} not found.");

                var employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    DateCreated = employee.DateCreated,
                    AdminName = employee.Admin.LastName, // Name of the admin who created the employee
                    DepartmentNames = employee.Departments.Select(d => d.Name).ToList() // Names of departments the employee is associated with
                };

                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in GetEmployee", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var admin = await _context.Admins.FindAsync(createEmployeeDto.AdminId);
                if (admin == null)
                    return BadRequest("Invalid Admin ID.");

                var departments = await _context.Departments
                    .Where(d => createEmployeeDto.DepartmentIds.Contains(d.Id))
                    .ToListAsync();

                var employee = new Employee
                {
                    FirstName = createEmployeeDto.FirstName,
                    LastName = createEmployeeDto.LastName,
                    Email = createEmployeeDto.Email,
                    AdminId = createEmployeeDto.AdminId,
                    DateCreated = DateTime.UtcNow,
                    Departments = departments
                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                var employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    DateCreated = employee.DateCreated,
                    AdminName = admin.LastName, // Admin's name
                    DepartmentNames = employee.Departments.Select(d => d.Name).ToList() // Department names
                };

                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employeeDto);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in CreateEmployee", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var employee = await _context.Employees
                    .Include(e => e.Departments) // Load the departments to update
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                    return NotFound($"Employee with ID {id} not found.");

                var departments = await _context.Departments
                    .Where(d => updateEmployeeDto.DepartmentIds.Contains(d.Id))
                    .ToListAsync();

                employee.FirstName = updateEmployeeDto.FirstName;
                employee.LastName = updateEmployeeDto.LastName;
                employee.Email = updateEmployeeDto.Email;
                employee.Departments = departments;

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                var employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    DateCreated = employee.DateCreated,
                    AdminName = employee.Admin.LastName, // Admin name
                    DepartmentNames = employee.Departments.Select(d => d.Name).ToList() // Department names
                };

                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in UpdateEmployee", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                    return NotFound($"Employee with ID {id} not found.");

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in DeleteEmployee", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // Helper method to log errors to the database
        private async Task LogErrorToDatabaseAsync(string context, Exception ex)
        {
            _logger.LogError($"{context}: {ex.Message}", ex);

            try
            {
                var errorLog = new ErrorLog
                {
                    ErrorMessage = ex.Message,
                    DateCreated = DateTime.UtcNow
                };

                _context.ErrorLogs.Add(errorLog);
                await _context.SaveChangesAsync();
            }
            catch (Exception logEx)
            {
                _logger.LogError($"Failed to log error to database: {logEx.Message}", logEx);
            }
        }
    }
}
