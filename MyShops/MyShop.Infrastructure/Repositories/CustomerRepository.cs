using MyShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using My_Shop.Core.Models;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer?> GetCustomerByUsernameAndPasswordAsync(string username, string password)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }
}