using MyShop.Domain.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Mappers;

public class CategoryMapper
{
    public static CategoryDto ToDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public static Category ToEntity(CategoryDto categoryDto)
    {
        return new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name
        };
    }
}