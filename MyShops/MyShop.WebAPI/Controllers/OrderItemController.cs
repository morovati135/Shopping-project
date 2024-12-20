using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;

namespace MyShop.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet("by-order/{orderId}")]
    public async Task<IActionResult> GetOrderItemsByOrderId(int orderId)
    {
        var orderItems = await _orderItemService.GetOrderItemsByOrderIdAsync(orderId);
        return Ok(orderItems);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrderItem([FromBody] OrderItemDto orderItemDto)
    {
        await _orderItemService.AddOrderItemAsync(orderItemDto);
        return Ok(new { Message = "Order item added successfully." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderItem(int id)
    {
        await _orderItemService.DeleteOrderItemAsync(id);
        return Ok(new { Message = "Order item deleted successfully." });
    }
}