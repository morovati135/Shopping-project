using My_Shop.Core.Models;

namespace My_Shop.Application.Services;

public interface ICustomerService
{
    Task<Customer?> GetCustomerById(int id);
    Task<Customer> Login(string username, string password);
    Task<Customer> Register(Customer customer);
    string GenerateJwtToken(Customer customer);
}