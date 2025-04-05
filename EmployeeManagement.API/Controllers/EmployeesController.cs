using EmployeeManagement.API.Services;
using EmployeeManagementData.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Create([FromBody] EmployeeDTO employee)
        {
            try
            {
                var createdEmployee = await _employeeService.CreateEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetById), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EmployeeDTO employee)
        {
            if (id != employee.EmployeeId) return BadRequest("ID mismatch");

            try
            {
                var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
                if (updatedEmployee == null) return NotFound();
                return Ok(employee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _employeeService.DeleteEmployeeAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
