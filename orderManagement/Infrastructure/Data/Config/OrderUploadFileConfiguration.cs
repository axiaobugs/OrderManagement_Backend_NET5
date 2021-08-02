using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderManagement.Entities.Orders;

namespace orderManagement.Infrastructure.Data.Config
{
    public class OrderUploadFileConfiguration:IEntityTypeConfiguration<OrderUploadFile>
    {
        public void Configure(EntityTypeBuilder<OrderUploadFile> builder)
        {
            builder.HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .IsRequired();
            builder.Property(x => x.OrderId)
                .IsRequired();
            builder.Property(x => x.FileUri)
                .HasDefaultValue("")
                .IsRequired();
        }
    }
}