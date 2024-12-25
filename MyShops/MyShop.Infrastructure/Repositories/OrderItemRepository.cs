using MyShop.Domain.Interfaces;
using MyShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories;

public class OrderItemRepository :IOrderItemRepository
{
    private readonly AppDbContext _context;

    public OrderItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        return await _context.OrderItems.Where(oi => oi.OrderId == orderId).ToListAsync();
    }

    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        _context.OrderItems.Add(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        var orderItem = await _context.OrderItems.FindAsync(id);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}