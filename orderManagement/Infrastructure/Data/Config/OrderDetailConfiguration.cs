using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Entities;
using orderManagement.Entities.Orders;

namespace orderManagement.Infrastructure.Data.Config
{
    public class OrderDetailConfiguration:IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.Category)
                .HasConversion(
                    c => c.ToString(),
                    c => (Category) Enum.Parse(typeof(Category), c));
            //builder.HasOne(x => x.Order)
            //    .WithMany(o => o.OrderDetails);
        }
    }
}