using AutoMapper;
using EmployeeManagementData.DTOs;
using EmployeeManagementData.Models;

namespace EmployeeManagementData.Mappings
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }

}
