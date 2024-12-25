using MyShop.Domain.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Mappers;

public class CustomerMapper
{
    public static CustomerDto ToDto(Customer customer)
    {
        return new CustomerDto
        {
            Username = customer.Username,
            Password = customer.Password
        };
    }

    public static Customer ToEntity(CustomerDto customerDto)
    {
        return new Customer
        {
            Username = customerDto.Username,
            Password = customerDto.Password
        };
    }
}