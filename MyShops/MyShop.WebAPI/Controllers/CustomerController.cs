using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;

namespace MyShop.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] CustomerDto customerDto)
    {
        var token = await _customerService.LoginAsync(customerDto.Username, customerDto.Password);
        if (token == null)
            return Unauthorized("Invalid username or password.");

        return Ok(new { Token = token });
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CustomerDto customerDto)
    {
        await _customerService.RegisterAsync(customerDto);
        return Ok(new { Message = "Registration successful." });
    }

}