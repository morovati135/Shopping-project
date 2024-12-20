using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _repository.GetAllCategoriesAsync();
        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        });
    }

    public async Task AddCategoryAsync(CategoryDto categoryDto)
    {
        var category = new My_Shop.Core.Models.Category
        {
            Name = categoryDto.Name
        };
        await _repository.AddCategoryAsync(category);
    }
}