using MyShop.Application.Interfaces;
using MyShop.Domain.Interfaces;
using MyShop.Application.DTOs;
using MyShop.Application.Mappers; 

namespace MyShop.Application.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _repository;

    public OrderItemService(IOrderItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        var orderItems = await _repository.GetOrderItemsByOrderIdAsync(orderId);

        // استفاده از Mapper برای تبدیل OrderItem به OrderItemDto
        return orderItems.Select(OrderItemMapper.ToDto);
    }

    public async Task AddOrderItemAsync(OrderItemDto orderItemDto)
    {
        // تبدیل OrderItemDto به OrderItem با استفاده از Mapper
        var orderItem = OrderItemMapper.ToEntity(orderItemDto);

        await _repository.AddOrderItemAsync(orderItem);
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        await _repository.DeleteOrderItemAsync(id);
    }
}