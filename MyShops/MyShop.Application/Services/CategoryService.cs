using Microsoft.Extensions.Caching.Memory;
using MyShop.Application.Interfaces;
using MyShop.Domain.Interfaces;
using MyShop.Application.DTOs;
using MyShop.Application.Mappers;

namespace MyShop.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMemoryCache _memoryCache;
    private readonly string cacheKey = "categories";

    public CategoryService(ICategoryRepository repository, IMemoryCache memoryCache)
    {
        _repository = repository;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = _memoryCache.Get<List<CategoryDto>>(cacheKey);
        if (categories == null)
        {
            var newCategories = new List<CategoryDto>()
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
           var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(60)) // Cache expires in 60 seconds
                .SetSlidingExpiration(TimeSpan.FromSeconds(30)); // Reset expiration if accessed within 30 seconds
            _memoryCache.Set(cacheKey, newCategories, cacheOptions);

            return newCategories;
            // var categories = await _repository.GetAllCategoriesAsync();
            //
            // // استفاده از CategoryMapper برای تبدیل Entity به DTO
            // return categories.Select(CategoryMapper.ToDto);
        }

        return categories;
    }

    public async Task AddCategoryAsync(CategoryDto categoryDto)
    {
        // تبدیل DTO به Entity با استفاده از CategoryMapper
        var category = CategoryMapper.ToEntity(categoryDto);

        // افزودن به پایگاه داده
        await _repository.AddCategoryAsync(category);
    }
}