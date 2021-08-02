using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Entities.Orders;

namespace orderManagement.Infrastructure.Data.Config
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // 
            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.CustomerId)
                .IsRequired();
            builder.HasOne(o => o.RequirementBase)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(o => o.OrderDetails)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
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