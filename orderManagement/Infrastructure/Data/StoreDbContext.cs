using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Entities.Employees;
using orderManagement.Entities.Customers;
using orderManagement.Entities.Employees;
using orderManagement.Entities.Orders;
using System.Reflection;
using orderManagement.Core.Entities.Orders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using orderManagement.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace orderManagement.Infrastructure.Data
{
    public class StoreDbContext: IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IConfiguration _configuration;

        public StoreDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
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
            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}