using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Entities.Customers;
using orderManagement.Entities.Payment;
using System;

namespace orderManagement.Infrastructure.Data.Config
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(x => x.Orders)
                .WithOne()
                .IsRequired();
            builder.Property(x => x.PaymentStatus)
                .HasConversion(
                    o => o.ToString(),
                    o => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), o))
                .IsRequired();
            builder.Property(x => x.PaymentMethod)
                .HasConversion(
                    o => o.ToString(),
                    o => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), o))
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Address)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(x => x.CompanyName)
                .HasMaxLength(255)
                .HasDefaultValue("null")
                .IsRequired();
            builder.Property(x => x.ContactNumber)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.DeliveryTo)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}