using Microsoft.EntityFrameworkCore;
using My_Shop.Core.Models;
using My_Shop.Infrastructure;

namespace My_Shop.Application.Services;

public class CustomerService : ICustomerService
{
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Login(string username, string password)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
        }

        public async Task<Customer> Register(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public string GenerateJwtToken(Customer customer)
        {
            // پیاده‌سازی تولید JWT
            return "Your-JWT-Token"; // نمونه
        }
}