using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Entities.Orders;
using System;
using orderManagement.Core.Entities.Orders;

namespace orderManagement.Infrastructure.Data.Config
{
    public class OrderRequirementBaseConfiguration:IEntityTypeConfiguration<OrderRequirementsBase>
    {
        public void Configure(EntityTypeBuilder<OrderRequirementsBase> builder)
        {
            //builder.HasOne(x => x.Order)
            //    .WithOne(x => x.RequirementBase);
            builder.Property(x => x.Material)
                .HasConversion(
                    o => o.ToString(),
                    o => (Materials)Enum.Parse(typeof(Materials), o))
                .HasDefaultValue(Materials.CheckPlat)
                .IsRequired();
            builder.Property(x => x.Thick)
                .HasConversion(
                    o => o.ToString(),
                    o => (Thickness)Enum.Parse(typeof(Thickness), o))
                .HasDefaultValue(Thickness.MiddleThick)
                .IsRequired();
            builder.HasMany(x => x.UploadFiles)
                .WithOne(uf=>uf.OrderRequirementsBase)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.DueDate)
                .IsRequired();
        }
    }
}