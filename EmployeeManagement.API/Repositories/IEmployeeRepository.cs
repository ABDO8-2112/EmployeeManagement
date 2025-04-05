using EmployeeManagementData.DTOs;
using EmployeeManagementData.Models;

namespace EmployeeManagement.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync(int page, int pageSize);
        Task<EmployeeDTO?> GetByIdAsync(int id);
        Task<EmployeeDTO> AddAsync(EmployeeDTO employee);
        Task<EmployeeDTO?> UpdateAsync(EmployeeDTO employee);
        Task<bool> DeleteAsync(int id);
    }
}