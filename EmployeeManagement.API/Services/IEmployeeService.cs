using EmployeeManagementData.DTOs;

namespace EmployeeManagement.API.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(int page, int pageSize);
        Task<EmployeeDTO?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employee);
        Task<EmployeeDTO?> UpdateEmployeeAsync(EmployeeDTO employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}