using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public CustomerService(ICustomerRepository repository, JwtTokenGenerator jwtTokenGenerator)
    {
        _repository = repository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    // متد ورود با تولید توکن JWT
    public async Task<string> LoginAsync(string username, string password)
    {
        // بررسی کاربر با نام کاربری و رمز عبور
        var customer = await _repository.GetCustomerByUsernameAndPasswordAsync(username, password);
        if (customer == null)
            return null;

        // تولید توکن JWT
        return _jwtTokenGenerator.GenerateToken(customer);
    }

    // متد ثبت‌نام
    public async Task RegisterAsync(CustomerDto customerDto)
    {
        // تبدیل DTO به مدل Customer
        var customer = new Customer
        {
            Username = customerDto.Username,
            Password = customerDto.Password
        };

        // افزودن کاربر به پایگاه داده
        await _repository.AddCustomerAsync(customer);
    }
}