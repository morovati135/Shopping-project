namespace My_Shop.Core.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    // ارتباط یک به چند با محصولات
    public ICollection<Product> Products { get; set; }
}