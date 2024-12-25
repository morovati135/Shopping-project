namespace MyShop.Domain.Models;

public class Order
{
    public int Id { get; set; }
    // کلید خارجی به مشتری
    public int CustomerId { get; set; } 
    // ارتباط با مشتری
    public Customer Customer { get; set; } 
    public DateTime OrderDate { get; set; }
    public bool IsFinalized { get; set; }
    // ارتباط با آیتم‌های سفارش
    public ICollection<OrderItem> OrderItems { get; set; } 
}