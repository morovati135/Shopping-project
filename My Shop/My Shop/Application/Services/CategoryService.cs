using My_Shop.Core.Models;
using My_Shop.Infrastructure.Repositories;

namespace My_Shop.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllCategoriesAsync();
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _categoryRepository.AddCategoryAsync(category);
    }
}