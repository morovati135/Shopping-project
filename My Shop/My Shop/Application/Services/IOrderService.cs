using My_Shop.Core.Models;

namespace My_Shop.Application.Services;

public interface IOrderService
{
    Task<Order> AddToCart(int customerId, int productId, int quantity);
    Task<Order> FinalizeOrder(int orderId);
    Task<Order> GetOrderById(int orderId);
}