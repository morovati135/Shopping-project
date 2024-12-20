using My_Shop.Core.Models;

namespace MyShop.Core.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
}