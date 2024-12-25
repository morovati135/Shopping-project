using MyShop.Domain.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Mappers;

public class OrderMapper
{
    public static OrderDto ToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            IsFinalized = order.IsFinalized
        };
    }

    public static Order ToEntity(OrderDto orderDto)
    {
        return new Order
        {
            Id = orderDto.Id,
            CustomerId = orderDto.CustomerId,
            OrderDate = orderDto.OrderDate,
            IsFinalized = orderDto.IsFinalized
        };
    }
}