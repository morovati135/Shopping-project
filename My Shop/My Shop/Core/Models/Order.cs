namespace My_Shop.Core.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsFinalized { get; set; }
}