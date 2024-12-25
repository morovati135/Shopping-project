using MyShop.Domain.Models;

namespace MyShop.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<Customer?> GetCustomerByUsernameAndPasswordAsync(string username, string password);
    Task AddCustomerAsync(Customer customer);
}