using Microsoft.EntityFrameworkCore;
using My_Shop.Core.Models;
using My_Shop.Infrastructure;

namespace My_Shop.Application.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> AddToCart(int customerId, int productId, int quantity)
    {
        var customerOrder = await _context.Orders
            .FirstOrDefaultAsync(o => o.CustomerId == customerId && !o.IsFinalized);

        if (customerOrder == null)
        {
            customerOrder = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                IsFinalized = false,
                OrderItems = new List<OrderItem>()
            };
            _context.Orders.Add(customerOrder);
        }

        var product = await _context.Products.FindAsync(productId);
        if (product == null) throw new Exception("Product not found");

        var orderItem = new OrderItem
        {
            Order = customerOrder,
            ProductId = productId,
            Quantity = quantity,
            Price = product.Price * quantity
        };

        customerOrder.OrderItems.Add(orderItem);
        await _context.SaveChangesAsync();

        return customerOrder;
    }

    public async Task<Order> FinalizeOrder(int orderId)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null || order.IsFinalized) throw new Exception("Order not found or already finalized");

        order.IsFinalized = true;
        await _context.SaveChangesAsync();

        return order;
    }

    public async Task<Order> GetOrderById(int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}