namespace MyShop.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    // ارتباط با سفارش‌ها
    public ICollection<Order> Orders { get; set; } 
    // فیلدهای JWT
    // برای ذخیره توکن بازنشانی
    public string? RefreshToken { get; set; } 
    // زمان انقضای توکن بازنشانی
    public DateTime? RefreshTokenExpiry { get; set; } 
}