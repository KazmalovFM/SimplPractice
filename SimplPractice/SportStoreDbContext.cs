using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Configuration;
using SimplPractice.Models;

namespace SimplPractice
{
    public class SportStoreDbContext(DbContextOptions<SportStoreDbContext> options)
    : DbContext(options)
    {
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}