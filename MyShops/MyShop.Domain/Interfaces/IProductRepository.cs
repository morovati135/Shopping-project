using MyShop.Domain.Models;

namespace MyShop.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<Product?> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
}