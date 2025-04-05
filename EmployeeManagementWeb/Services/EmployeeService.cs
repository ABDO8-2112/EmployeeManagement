using EmployeeManagementWeb.Models;

namespace EmployeeManagementWeb.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7008/api/employees";

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeModel>> GetAllEmployees(int page = 1, int pageSize = 5)
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeModel>>($"{ApiBaseUrl}?page={page}&pageSize={pageSize}");
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<EmployeeModel>($"{ApiBaseUrl}/{id}");
        }

        public async Task CreateEmployee(EmployeeModel employee)
        {
            await _httpClient.PostAsJsonAsync(ApiBaseUrl, employee);
        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            await _httpClient.PutAsJsonAsync($"{ApiBaseUrl}/{employee.EmployeeId}", employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
        }
    }
}
