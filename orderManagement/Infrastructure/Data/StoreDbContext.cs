using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using orderManagement.Entities.Customers;
using orderManagement.Entities.Employees;
using orderManagement.Entities.Orders;
using orderManagement.Infrastructure.Data.Config;

namespace orderManagement.Infrastructure.Data
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderRequirementsBase> OrderRequirementsBases { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderUploadFile> OrderUploadFiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}