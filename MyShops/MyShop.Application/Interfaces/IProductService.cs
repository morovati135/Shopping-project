using My_Shop.Core.Models;

namespace MyShop.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<Product?> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
}