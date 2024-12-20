using My_Shop.Core.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto?> LoginAsync(string username, string password);
    Task RegisterAsync(CustomerDto customerDto);
}