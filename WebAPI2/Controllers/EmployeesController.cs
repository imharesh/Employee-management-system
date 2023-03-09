using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI2.Data;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly WebAPI2Context _context;

        public EmployeesController(WebAPI2Context context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
           
            var employees = await _context.Employee.Include(e => e.Department).ToListAsync();
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        { 
            // Get Employee data using Employee ID 
            var employee = await _context.Employee.Include(e => e.Department).FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
         
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {

           var existingemp = await _context.Employee.FindAsync(id);

            if (existingemp == null)
            {
                return NotFound("Employee not found.");
            }

            var department = _context.Department.FirstOrDefault(d => d.DepartmentId == employee.DepartmentId);

            if (department == null)
            {
                return NotFound("Department not found.");
            }
            existingemp.Name = employee.Name;
            existingemp.Age = employee.Age;
            existingemp.DepartmentId = employee.DepartmentId;
            existingemp.Department = employee.Department;
            existingemp.Salary = employee.Salary;
            await _context.SaveChangesAsync();
            return Ok(existingemp);
        }


        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          
            var department = await _context.Department.FindAsync(employee.DepartmentId);

            if (department == null)
            {
                return NotFound("Department Not Found.");
            }
            employee.Department = department;
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
     
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
