using MyShop.Application.Interfaces;
using MyShop.Core.Interfaces;
using My_Shop.Core.Models;

namespace MyShop.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> LoginAsync(string username, string password)
    {
        return await _repository.GetCustomerByUsernameAndPasswordAsync(username, password);
    }

    public async Task RegisterAsync(Customer customer)
    {
        await _repository.AddCustomerAsync(customer);
    }
}