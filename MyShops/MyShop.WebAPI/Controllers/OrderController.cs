using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;

namespace MyShop.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound("Order not found.");
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] OrderDto orderDto)
    {
        await _orderService.AddOrderAsync(orderDto);
        return Ok(new { Message = "Order created successfully." });
    }

    [HttpGet("by-customer/{customerId}")]
    public async Task<IActionResult> GetOrdersByCustomer(int customerId)
    {
        var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
        return Ok(orders);
    }
}