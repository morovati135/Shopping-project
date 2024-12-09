using Microsoft.AspNetCore.Mvc;
using My_Shop.Application.Services;
using My_Shop.Core.Models;

namespace My_Shop.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        await _categoryService.AddCategoryAsync(category);
        return Ok(new { Message = "Category added successfully." });
    }
}