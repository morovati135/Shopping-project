namespace MyShop.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    // کلید خارجی به دسته‌بندی
    public int CategoryId { get; set; } 
    // ارتباط با دسته‌بندی
    public Category Category { get; set; } 
    // ارتباط با آیتم‌های سفارش
    public ICollection<OrderItem> OrderItems { get; set; } 
}