using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Core.Entities.Employees;
using orderManagement.Entities.Employees;

namespace orderManagement.Infrastructure.Data.Config
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne<Department>(d => d.Department)
                .WithMany(e=>e.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Address)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.BirthDate)
                .IsRequired();
            builder.Property(x => x.WeChat)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.HireDate)
                .IsRequired();
            builder.Property(x => x.SuperAccount)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.AnnualLeave)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(x => x.SickLeave)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(x => x.PayRate)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

        }
    }
}