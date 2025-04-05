using EmployeeManagementWeb.Models;

namespace EmployeeManagementWeb.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllEmployees(int page = 1, int pageSize = 5);
        Task<EmployeeModel> GetEmployeeById(int id);
        Task CreateEmployee(EmployeeModel employee);
        Task UpdateEmployee(EmployeeModel employee);
        Task DeleteEmployee(int id);
    }
}
