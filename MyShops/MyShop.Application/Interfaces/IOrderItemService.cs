using My_Shop.Core.Models;

namespace MyShop.Application.Interfaces;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    Task AddOrderItemAsync(OrderItem orderItem);
    Task DeleteOrderItemAsync(int id);
}