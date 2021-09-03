using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using orderManagement.Core.Entities.Employees;
using orderManagement.Dtos.Employees;

namespace orderManagement.Infrastructure.Data
{
    /// <summary>
    /// read seed data from json to the database 
    /// </summary>
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Employees.Any())
                {
                    var employeesData = await File.ReadAllTextAsync(
                        "H:\\project\\dotnet\\back-end\\orderManagement\\orderManagement\\Infrastructure\\Data\\SeedData\\generated.json");
                    var option = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive=true
                    };
                    var employeesCreateDto = JsonSerializer.Deserialize<List<EmployeeCreateDto>>(employeesData,option);
                    foreach (var employeeCreate in employeesCreateDto)
                    {
                        var employee =  Employee.CreateEmployee(employeeCreate);
                        Console.WriteLine(employee.Name);
                        context.Employees.Add(employee);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e.Message);
            }
        }
    }
}