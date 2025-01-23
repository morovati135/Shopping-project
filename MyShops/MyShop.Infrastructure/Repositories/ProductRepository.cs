using MyShop.Domain.Interfaces;
using MyShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return new List<Product>() { new Product()
        {
            Name = "Some product",
            Id = 1,
            CategoryId = 1,
            Price = 10000,
        },
            new Product()
            {
                Name = "Some product",
                Id = 1,
                CategoryId = 1,
                Price = 10000,
            },
            new Product()
            {
            Name = "Some product",
            Id = 1,
            CategoryId = 1,
            Price = 10000,
        },
        new Product()
        {
            Name = "Some product",
            Id = 1,
            CategoryId = 1,
            Price = 10000,
        }
        };
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }  
}