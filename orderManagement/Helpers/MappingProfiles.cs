using AutoMapper;
using orderManagement.Core.Entities.Employees;
using orderManagement.Core.Entities.Identity;
using orderManagement.Core.Entities.Orders;
using orderManagement.Dtos.Employees;
using orderManagement.Dtos.Identity;
using orderManagement.Dtos.Order;
using orderManagement.Entities.Customers;
using orderManagement.Entities.Orders;

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

            CreateMap<Order, OrderReturnDto>()
                .ForMember(d=>d.OrderRequirementsBase,o=>o.MapFrom(s=>s.RequirementBase))
                .ForMember(d=>d.OrderDetails,o=>o.MapFrom(s=>s.OrderDetails))
                .ReverseMap();

            CreateMap<OrderRequirementBaseDto, OrderRequirementsBase>()
                .ForMember(d => d.Material, o => o.MapFrom(s => s.Material))
                .ForMember(d => d.Thick, o => o.MapFrom(s => s.Thick))
                .ReverseMap();
            CreateMap<OrderDetailDto, OrderDetail>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category))

                .ReverseMap();
            CreateMap<CustomerDto, Customer>()
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => s.PaymentStatus))
                .ForMember(d => d.PaymentMethod, o => o.MapFrom(s => s.PaymentMethod))
                .ForMember(d => d.Orders, o => o.MapFrom(s => s.Orders))
                .ReverseMap();
            CreateMap<OrderCreateDto, Order>()
                .ForMember(d => d.OrderCode, o => o.MapFrom(s => s.OrderCode))
                .ForMember(d => d.OrderStatus, o => o.MapFrom(s => s.OrderStatus));
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppRole, RoleDto>();
            CreateMap<AppUser, UserDto>();
        }


    }
}