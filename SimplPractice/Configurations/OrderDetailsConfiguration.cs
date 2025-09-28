using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;
using System.Threading;


namespace SimplPractice.Configuration
{
    /// <summary>
    /// Конфигурация сущности OrderDetails для Fluent API.
    /// Определяет таблицу, ключи и связи с сущностями Order и Product.
    /// </summary>
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
