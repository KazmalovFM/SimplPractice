using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;

namespace SimplPractice
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)

        {
            builder.ToTable("Order Details");
            builder.HasKey(od => od.Id);

            builder.HasOne(od => od.Order)
                   .WithMany()
                   .HasForeignKey(od => od.OrderId);

            builder.HasOne(od => od.Product)
                   .WithMany()
                   .HasForeignKey(od => od.ProductId);
        }
    }
}