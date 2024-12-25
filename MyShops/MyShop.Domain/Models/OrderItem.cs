namespace MyShop.Domain.Models;

public class OrderItem
{
    public int Id { get; set; }
    // کلید خارجی به سفارش
    public int OrderId { get; set; } 
    // کلید خارجی به محصول
    public int ProductId { get; set; } 
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    // ارتباط با سفارش
    public Order Order { get; set; } 
    // ارتباط با محصول
    public Product Product { get; set; } 
}