using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;

namespace MyShop.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _repository.GetOrderByIdAsync(id);
    }

    public async Task AddOrderAsync(Order order)
    {
        await _repository.AddOrderAsync(order);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
    {
        return await _repository.GetOrdersByCustomerIdAsync(customerId);
    }
}