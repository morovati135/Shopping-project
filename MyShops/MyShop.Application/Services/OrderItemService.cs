using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;
namespace MyShop.Application.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _repository;

    public OrderItemService(IOrderItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        return await _repository.GetOrderItemsByOrderIdAsync(orderId);
    }

    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        await _repository.AddOrderItemAsync(orderItem);
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        await _repository.DeleteOrderItemAsync(id);
    }
}