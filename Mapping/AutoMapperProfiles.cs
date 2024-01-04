using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Requests;
using EmployeeManagement.Models.Response;

namespace EmployeeManagement.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddDepartmentRequest, Department>();
            CreateMap<Department, GetDepartmentResponse>();
            CreateMap<AddEmployeeRequest, Employee>();
            CreateMap<Employee, GetEmployeeResponse>();
            CreateMap<Department, GetDepartmentResponse[]>();
            CreateMap<Department, GetDepartmentWithEmployeesResponse>();
        }
    }
}
