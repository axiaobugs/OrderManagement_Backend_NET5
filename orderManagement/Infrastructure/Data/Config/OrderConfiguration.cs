using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Core.Entities.Employees;
using orderManagement.Entities.Employees;
using orderManagement.Entities.Orders;

namespace orderManagement.Infrastructure.Data.Config
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // 
            builder.HasOne(o => o.Customer)
                .WithMany(c=>c.Orders)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.CustomerId)
                .IsRequired();
            builder.HasOne(o => o.RequirementBase)
                .WithOne(r=>r.Order)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(o => o.OrderDetails)
                .WithOne(od=>od.Order)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<Employee>(e => e.Employees)
                .WithMany(o => o.Orders)
                .UsingEntity(j => j.ToTable("T_Orders_Employees"));
            // Enumerated types are stored by value
            builder.Property(c => c.OrderCode)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderCode)Enum.Parse(typeof(OrderCode), o))
                .IsRequired();
            builder.Property(c => c.OrderStatus)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o))
                .IsRequired();
            // Format of the price of amount
            builder.Property(o => o.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(x => x.OrderNumber)
                .IsRequired();
        }
    }
}