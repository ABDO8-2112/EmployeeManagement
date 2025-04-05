using EmployeeManagementData.DTOs;
using EmployeeManagement.API.Repositories;

namespace EmployeeManagement.API.Services
{
   public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employee)
        {            
            if (employee.Salary <= 0)
                throw new ArgumentException("Salary must be positive");

            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<EmployeeDTO?> UpdateEmployeeAsync(EmployeeDTO employee)
        {            
            if (employee.Salary <= 0)
                throw new ArgumentException("Salary must be positive");

            return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepository.DeleteAsync(id);
        }
    }
}
