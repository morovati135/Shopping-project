using MyShop.Domain.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Interfaces;

public interface IOrderService
{
    Task<OrderDto?> GetOrderByIdAsync(int id);
    Task AddOrderAsync(OrderDto orderDto); 
    Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId); 
}