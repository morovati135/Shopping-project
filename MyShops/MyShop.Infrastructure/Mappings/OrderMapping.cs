using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Models;

namespace MyShop.Infrastructure.Mappings;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // نام جدول
        builder.ToTable("Orders"); 
        // کلید اصلی
        builder.HasKey(o => o.Id); 
        // تاریخ سفارش اجباری
        builder.Property(o => o.OrderDate)
            .IsRequired(); 
        // مقدار پیش‌فرض برای Finalized
        builder.Property(o => o.IsFinalized)
            .HasDefaultValue(false);
        // ارتباط با Customer
        builder.HasOne(o => o.Customer) 
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); 
        // ارتباط با OrderItems
        builder.HasMany(o => o.OrderItems) 
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}

// توضیخات شخصی و جهت درک بهتر است