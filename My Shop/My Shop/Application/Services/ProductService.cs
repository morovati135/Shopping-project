using Microsoft.EntityFrameworkCore;
using My_Shop.Core.Models;
using My_Shop.Infrastructure;

namespace My_Shop.Application.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsByCategory(int categoryId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}