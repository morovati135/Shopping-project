using MyShop.Application.Interfaces;
using MyShop.Domain.Interfaces;
using MyShop.Application.DTOs;
using MyShop.Application.Mappers; 

namespace MyShop.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _repository.GetAllProductsAsync();

        
        return products.Select(ProductMapper.ToDto);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(int categoryId)
    {
        var products = await _repository.GetProductsByCategoryIdAsync(categoryId);

        
        return products.Select(ProductMapper.ToDto);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _repository.GetProductByIdAsync(id);
        if (product == null) return null;

        
        return ProductMapper.ToDto(product);
    }

    public async Task AddProductAsync(ProductDto productDto)
    {
        
        var product = ProductMapper.ToEntity(productDto);

        await _repository.AddProductAsync(product);
    }
}