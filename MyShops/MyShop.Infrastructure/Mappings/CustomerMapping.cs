using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Models;
namespace MyShop.Infrastructure.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers"); // نام جدول در دیتابیس

        builder.HasKey(c => c.Id); // کلید اصلی

        builder.Property(c => c.Username)
            .IsRequired()
            .HasMaxLength(100); // محدودیت برای Username

        builder.Property(c => c.Password)
            .IsRequired()
            .HasMaxLength(100); // محدودیت برای Password
    }
}