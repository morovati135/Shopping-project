using MyShop.Application.Interfaces;
using MyShop.Domain.Interfaces;
using MyShop.Application.DTOs;
using MyShop.Application.Mappers; 

namespace MyShop.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly ICacheManager _cacheManager;

    public ProductService(IProductRepository repository, ICacheManager cacheManager)
    {
        _repository = repository;
        _cacheManager = cacheManager;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var key="products";
        var result = await _cacheManager.GetAsync<System.Collections.Generic.List<ProductDto>>(key);
        if (result == null) 
        {
            var products = await _repository.GetAllProductsAsync();
            result=products.Select(ProductMapper.ToDto).ToList();
           await _cacheManager.SetAsync(key,result,TimeSpan.FromHours(1));
        }
        return result;
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