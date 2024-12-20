using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto?> LoginAsync(string username, string password)
    {
        var customer = await _repository.GetCustomerByUsernameAndPasswordAsync(username, password);
        if (customer == null) return null;

        return new CustomerDto
        {
            Username = customer.Username,
            Password = customer.Password
        };
    }

    public async Task RegisterAsync(CustomerDto customerDto)
    {
        var customer = new Customer
        {
            Username = customerDto.Username,
            Password = customerDto.Password
        };
        await _repository.AddCustomerAsync(customer);
    }
}