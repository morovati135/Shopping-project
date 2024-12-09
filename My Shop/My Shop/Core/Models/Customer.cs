namespace My_Shop.Core.Models;

public class Customer
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string JwtToken { get; set; }
}