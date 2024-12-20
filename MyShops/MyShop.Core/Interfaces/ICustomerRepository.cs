using My_Shop.Core.Models;

namespace MyShop.Core.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<Customer?> GetCustomerByUsernameAndPasswordAsync(string username, string password);
    Task AddCustomerAsync(Customer customer);
}