using MyShop.Core.Interfaces;
using My_Shop.Core.Models;
using Microsoft.EntityFrameworkCore;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
    {
        return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
    }
}