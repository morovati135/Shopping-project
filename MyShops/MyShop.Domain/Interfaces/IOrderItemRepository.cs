using MyShop.Domain.Models;

namespace MyShop.Domain.Interfaces;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    Task AddOrderItemAsync(OrderItem orderItem);
    Task DeleteOrderItemAsync(int id);
}