using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;

namespace SimplPractice
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)

        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Supplier)
                   .WithMany()
                   .HasForeignKey(p => p.SupplierId);
            
            builder.HasOne(p => p.Store)
                   .WithMany()
                   .HasForeignKey(p => p.StoreId);
        }
    }
}
