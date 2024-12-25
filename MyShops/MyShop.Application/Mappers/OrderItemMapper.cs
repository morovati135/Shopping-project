using MyShop.Domain.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Mappers;

public class OrderItemMapper
{
    public static OrderItemDto ToDto(OrderItem orderItem)
    {
        return new OrderItemDto
        {
            Id = orderItem.Id,
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price
        };
    }

    public static OrderItem ToEntity(OrderItemDto orderItemDto)
    {
        return new OrderItem
        {
            Id = orderItemDto.Id,
            OrderId = orderItemDto.OrderId,
            ProductId = orderItemDto.ProductId,
            Quantity = orderItemDto.Quantity,
            Price = orderItemDto.Price
        };
    }
}