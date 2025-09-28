using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;
using System.Threading;


namespace SimplPractice.Configuration
{
    /// <summary>
    /// Конфигурация сущности Payment для Fluent API.
    /// Определяет таблицу, ключи и связи с сущностями Order.
    /// </summary>
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)

        {
            builder.ToTable("Payment");
            builder.HasKey(pay => pay.Id);

            builder.HasOne(pay => pay.Order)
                   .WithMany()
                   .HasForeignKey(pay => pay.OrderId);
        }
    }
}