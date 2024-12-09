using Microsoft.AspNetCore.Mvc;
using My_Shop.Application.DTOs;
using My_Shop.Application.Services;

namespace My_Shop.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("add-to-cart")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
    {
        var order = await _orderService.AddToCart(addToCartDto.CustomerId, addToCartDto.ProductId, addToCartDto.Quantity);
        return Ok(order);
    }

    [HttpPost("finalize")]
    public async Task<IActionResult> FinalizeOrder(int orderId)
    {
        var order = await _orderService.FinalizeOrder(orderId);
        if (order == null)
            return BadRequest("Order cannot be finalized.");
        return Ok(order);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order == null)
            return NotFound("Order not found.");
        return Ok(order);
    }
}