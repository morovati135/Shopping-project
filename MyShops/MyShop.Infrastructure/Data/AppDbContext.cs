using Microsoft.EntityFrameworkCore;
using My_Shop.Core.Models;

namespace MyShop.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    // تعریف DbSet‌ها برای مدل‌ها
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // تنظیمات خاص برای مدل‌ها در اینجا انجام می‌شود
        // تنظیم کلید خارجی در OrderItem 
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);

        // تنظیم کلید خارجی در Order
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        // تنظیم مقدار پیش‌فرض 
        modelBuilder.Entity<Customer>()
            .Property(c => c.Username)
            .IsRequired(); 

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .IsRequired(); 
        
        // تنظیم دقیق برای Price در Product
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        // تنظیم دقیق برای Price در OrderItem
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Price)
            .HasPrecision(18, 2);
    }
}