using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplPractice.Models;
using System.Threading;


namespace SimplPractice.Configuration
{
    /// <summary>
    /// Конфигурация сущности Products для Fluent API.
    /// Определяет таблицу, ключи и связи с сущностями Category, Supplier и Store.
    /// </summary>
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
