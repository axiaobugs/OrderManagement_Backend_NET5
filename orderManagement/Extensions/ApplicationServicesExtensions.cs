﻿using Microsoft.Extensions.DependencyInjection;
using orderManagement.Core.Interface;
using orderManagement.Infrastructure.Data.Repository;
using orderManagement.Infrastructure.Services;

namespace orderManagement.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}