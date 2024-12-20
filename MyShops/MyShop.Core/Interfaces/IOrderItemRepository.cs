using My_Shop.Core.Models;

namespace MyShop.Core.Interfaces;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    Task AddOrderItemAsync(OrderItem orderItem);
    Task DeleteOrderItemAsync(int id);
}