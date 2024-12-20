using My_Shop.Core.Models;

namespace MyShop.Application.Interfaces;

public interface IOrderService
{
    Task<Order?> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
}