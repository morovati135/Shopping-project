using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        var order = await _repository.GetOrderByIdAsync(id);
        if (order == null) return null;

        return new OrderDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            IsFinalized = order.IsFinalized
        };
    }

    public async Task AddOrderAsync(OrderDto orderDto)
    {
        var order = new My_Shop.Core.Models.Order
        {
            CustomerId = orderDto.CustomerId,
            OrderDate = orderDto.OrderDate,
            IsFinalized = orderDto.IsFinalized
        };
        await _repository.AddOrderAsync(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
    {
        var orders = await _repository.GetOrdersByCustomerIdAsync(customerId);
        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            CustomerId = o.CustomerId,
            OrderDate = o.OrderDate,
            IsFinalized = o.IsFinalized
        });
    }
}