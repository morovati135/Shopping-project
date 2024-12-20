using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;

namespace MyShop.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("by-category/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategory(int categoryId)
    {
        var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
    {
        await _productService.AddProductAsync(productDto);
        return Ok(new { Message = "Product added successfully." });
    }
}