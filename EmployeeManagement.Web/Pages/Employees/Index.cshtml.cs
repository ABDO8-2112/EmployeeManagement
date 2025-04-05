using EmployeeManagement.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.Web.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public List<Employee> Employees = new List<Employee>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string Search { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HiredAfter { get; set; }

        public async Task OnGetAsync(int? pageNumber, string search, string position,
        decimal? salary, DateTime? hiredAfter)
        {
            PageSize = 5;
            CurrentPage = pageNumber ?? 1;
            Search = search ?? string.Empty;
            Position = position ?? string.Empty;
            Salary = salary;
            HiredAfter = hiredAfter;

            var apiUrl = $"{_configuration["ApiBaseUrl"]}/employees?" +
                         $"search={Search}" +
                         $"&position={Position}" +
                         $"&Salary={Salary}" +
                         $"&hiredAfter={HiredAfter?.ToString("yyyy-MM-dd")}";

            Employees = await _httpClient.GetFromJsonAsync<List<Employee>>(apiUrl) ?? new();
            TotalPages = (int)Math.Ceiling(Employees.Count / (double)PageSize);
        }
    }
}
