using AutoMapper;
using orderManagement.Core.Entities.Employees;
using orderManagement.Dtos.Employees;

namespace orderManagement.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeCreateDto,Employee>();
        }

        
    }
}