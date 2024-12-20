using My_Shop.Core.Models;

namespace MyShop.Application.Interfaces;

public interface ICustomerService
{
    Task<Customer?> LoginAsync(string username, string password);
    Task RegisterAsync(Customer customer);
}