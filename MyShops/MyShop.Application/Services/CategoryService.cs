using MyShop.Application.Interfaces;
using MyShop.Domain.Interfaces;
using MyShop.Application.DTOs;
using MyShop.Application.Mappers; 

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
        // var categories = await _repository.GetAllCategoriesAsync();
        //
        // // استفاده از CategoryMapper برای تبدیل Entity به DTO
        // return categories.Select(CategoryMapper.ToDto);
        return new List<CategoryDto>()
        {
            new CategoryDto()
            {
                Name = "wadaw",
                Id = 1
            },
            new CategoryDto()
            {
                Name = "dsadsad",
                Id = 2
            }
        };
    }

    public async Task AddCategoryAsync(CategoryDto categoryDto)
    {
        // تبدیل DTO به Entity با استفاده از CategoryMapper
        var category = CategoryMapper.ToEntity(categoryDto);

        // افزودن به پایگاه داده
        await _repository.AddCategoryAsync(category);
    }
}