using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Entities.Employees;

namespace orderManagement.Infrastructure.Data.Config
{
    public class DepartmentConfiguration:IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany<Employee>(e => e.Employees)
                .WithOne(d => d.Department)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.ManagerId)
                .IsRequired();
        }
    }
}