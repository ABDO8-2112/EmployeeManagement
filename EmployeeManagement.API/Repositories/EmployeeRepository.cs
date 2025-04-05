using AutoMapper;
using EmployeeManagementData.Data;
using EmployeeManagementData.DTOs;
using EmployeeManagementData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var employeeList = await _context.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employeeList);
        }

        public async Task<EmployeeDTO?> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<EmployeeDTO> AddAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<EmployeeDTO?> UpdateAsync(EmployeeDTO employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.EmployeeId);
            if (existingEmployee == null) return null;

            _context.Entry(existingEmployee).CurrentValues.SetValues(employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(existingEmployee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}