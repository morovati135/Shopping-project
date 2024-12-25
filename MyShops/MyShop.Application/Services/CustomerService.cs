using MyShop.Application.Interfaces;
using MyShop.Domain.Interfaces;
using MyShop.Application.DTOs;
using MyShop.Application.Mappers; 

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
        // تبدیل DTO به مدل Customer با استفاده از CustomerMapper
        var customer = CustomerMapper.ToEntity(customerDto);

        // افزودن کاربر به پایگاه داده
        await _repository.AddCustomerAsync(customer);
    }
}