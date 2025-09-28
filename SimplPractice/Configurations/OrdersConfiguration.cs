using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;
using System.Threading;

namespace SimplPractice.Configuration
{
    /// <summary>
    /// Конфигурация сущности Orders для Fluent API.
    /// Определяет таблицу, ключи и связи с сущностями Client, Employee и Delivery.
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Client)
                   .WithMany()
                   .HasForeignKey(o => o.ClientId);

            builder.HasOne(o => o.Employee)
                   .WithMany()
                   .HasForeignKey(o => o.EmployeeId);

            builder.HasOne(o => o.Delivery)
                   .WithOne(d => d.Order)
                   .HasForeignKey<Delivery>(d => d.OrderId);
        }
    }
}
