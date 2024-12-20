using My_Shop.Core.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Interfaces;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderId);
    Task AddOrderItemAsync(OrderItemDto orderItemDto); 
    Task DeleteOrderItemAsync(int id);
}