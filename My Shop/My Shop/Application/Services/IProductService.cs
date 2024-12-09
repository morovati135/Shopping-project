using My_Shop.Core.Models;

namespace My_Shop.Application.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsByCategory(int categoryId);
    Task<Product> GetProductById(int id);
    Task AddProduct(Product product);
}