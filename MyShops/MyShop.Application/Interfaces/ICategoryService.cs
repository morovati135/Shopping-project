using MyShop.Domain.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task AddCategoryAsync(CategoryDto categoryDto);
}