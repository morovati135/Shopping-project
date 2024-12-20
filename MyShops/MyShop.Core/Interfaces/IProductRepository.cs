using My_Shop.Core.Models;

namespace MyShop.Core.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<Product?> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
}