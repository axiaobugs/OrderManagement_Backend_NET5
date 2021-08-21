using AutoMapper;
using orderManagement.Core.Entities.Employees;
using orderManagement.Dtos.Employees;
using orderManagement.Entities.Employees;

namespace orderManagement.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeReturnDto>()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department.Name))
                .ForMember(d=>d.DepartmentId,o=>o.MapFrom(s=>s.DepartmentId));
            CreateMap<EmployeeReturnDto, Employee>();

        }

        
    }
}