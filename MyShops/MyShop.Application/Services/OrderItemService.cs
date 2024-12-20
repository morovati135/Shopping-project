using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;
using MyShop.Application.DTOs;

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
        return orderItems.Select(oi => new OrderItemDto
        {
            Id = oi.Id,
            OrderId = oi.OrderId,
            ProductId = oi.ProductId,
            Quantity = oi.Quantity,
            Price = oi.Price
        });
    }

    public async Task AddOrderItemAsync(OrderItemDto orderItemDto)
    {
        var orderItem = new My_Shop.Core.Models.OrderItem
        {
            OrderId = orderItemDto.OrderId,
            ProductId = orderItemDto.ProductId,
            Quantity = orderItemDto.Quantity,
            Price = orderItemDto.Price
        };
        await _repository.AddOrderItemAsync(orderItem);
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        await _repository.DeleteOrderItemAsync(id);
    }
}