using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;

namespace MyShop.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _repository.GetAllCategoriesAsync();
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _repository.AddCategoryAsync(category);
    }
}