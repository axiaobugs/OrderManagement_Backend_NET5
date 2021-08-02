﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Entities.Orders;
using System;

namespace orderManagement.Infrastructure.Data.Config
{
    public class OrderRequirementBaseConfiguration:IEntityTypeConfiguration<OrderRequirementsBase>
    {
        public void Configure(EntityTypeBuilder<OrderRequirementsBase> builder)
        {
            builder.HasOne(x => x.Order)
                .WithOne()
                .HasForeignKey<Order>(o=>o.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
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
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.DueDate)
                .IsRequired();
            builder.Property(x => x.OrderId)
                .IsRequired();
        }
    }
}