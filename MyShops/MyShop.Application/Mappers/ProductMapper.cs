using MyShop.Application.DTOs;
using MyShop.Domain.Models;
namespace MyShop.Application.Mappers;

public class ProductMapper
{
    public static ProductDto ToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
    }

    public static Product ToEntity(ProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            CategoryId = productDto.CategoryId
        };
    }
}