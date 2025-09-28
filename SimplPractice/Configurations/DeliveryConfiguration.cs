using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;
using System.Threading;


namespace SimplPractice.Configuration
{
    /// <summary>
    /// Конфигурация сущности Delivery для Fluent API.
    /// Определяет таблицу, ключи и связи с сущностями Order и DeliveryStatus.
    /// </summary>
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)

        {
            builder.ToTable("Delivery");
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Order)
                   .WithOne(o => o.Delivery)
                   .HasForeignKey<Delivery>(d => d.OrderId);

            builder.HasOne(d => d.DeliveryStatus)
                   .WithMany()
                   .HasForeignKey(d => d.DeliveryStatusId);
        }
    }
}