using MyShop.Domain.Models;

namespace MyShop.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
}