using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using My_Shop.Application.DTOs;
using My_Shop.Application.Services;
using My_Shop.Core.Models;

namespace My_Shop.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Customer customerDto)
    {
        var result = await _customerService.Register(customerDto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] CustomerDto customerDto)
    {
        var result = await _customerService.Login(customerDto.Username, customerDto.Password);
        if (result == null)
            return Unauthorized("Invalid username or password.");

        return Ok(new { Token = _customerService.GenerateJwtToken(result) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerById(id);
        if (customer == null)
            return NotFound("Customer not found.");
        return Ok(customer);
    }
}