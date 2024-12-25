using MyShop.Domain.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(int categoryId); 
    Task<ProductDto?> GetProductByIdAsync(int id); 
    Task AddProductAsync(ProductDto productDto);
    }