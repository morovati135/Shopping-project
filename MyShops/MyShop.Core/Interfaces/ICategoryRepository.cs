using My_Shop.Core.Models;

namespace MyShop.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task AddCategoryAsync(Category category);
}