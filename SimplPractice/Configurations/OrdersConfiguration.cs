using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;

namespace SimplPractice.Configuration
{
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
