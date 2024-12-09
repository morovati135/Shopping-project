using Microsoft.EntityFrameworkCore;
using My_Shop.Core.Models;
using My_Shop.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace My_Shop.Application.Services;

public class CustomerService : ICustomerService
{
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<string?> Login(string username, string password)
        {
            // بررسی کاربر در دیتابیس
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Username == username && c.Password == password);

            if (customer == null)
                // بازگرداندن null در صورت عدم وجود کاربر
                return null; 

            // تولید توکن JWT
            return GenerateJwtToken(customer);
        }

        public async Task<Customer> Register(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public string GenerateJwtToken(Customer customer)
        {
            // تنظیمات JWT
            var key = Encoding.UTF8.GetBytes("YourSuperSecretKeyHere12345"); // کلید باید از appsettings.json خوانده شود.
            var issuer = "MyApi";
            var audience = "MyApiUsers";
            var durationInMinutes = 60;

            // ایجاد Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, customer.Username)
            };

            // امضای توکن
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            // ایجاد توکن
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(durationInMinutes),
                signingCredentials: credentials);

            // بازگرداندن توکن
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
}

//توضیحات برای خودم هست تا یادم باشه چیکار کردم