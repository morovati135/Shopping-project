using MyShop.Application.Interfaces;
using MyShop.Domain.Interfaces;
using MyShop.Application.DTOs;
using MyShop.Application.Mappers; 

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

        // تبدیل Order به OrderDto با استفاده از OrderMapper
        return OrderMapper.ToDto(order);
    }

    public async Task AddOrderAsync(OrderDto orderDto)
    {
        // تبدیل OrderDto به Order با استفاده از OrderMapper
        var order = OrderMapper.ToEntity(orderDto);

        await _repository.AddOrderAsync(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
    {
        var orders = await _repository.GetOrdersByCustomerIdAsync(customerId);

        // تبدیل لیست Order به OrderDto با استفاده از OrderMapper
        return orders.Select(OrderMapper.ToDto);
    }
}