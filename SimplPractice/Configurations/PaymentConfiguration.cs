using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;

namespace SimplPractice
{
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