using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using orderManagement.Core.Interface;
using orderManagement.Infrastructure.Data.Repository;

namespace orderManagement.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
 
            return services;
        }
    }
}