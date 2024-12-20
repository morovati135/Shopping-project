using System.Data;
using Dapper;
using My_Shop.Core.Models;
using MyShop.Core.Interfaces;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DapperDbConnection _dbConnection;

    public CategoryRepository(DapperDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        using var connection = _dbConnection.CreateConnection();
        const string query = "SELECT * FROM Categories";
        return await connection.QueryAsync<Category>(query);
    }

    public async Task AddCategoryAsync(Category category)
    {
        using var connection = _dbConnection.CreateConnection();
        const string query = "INSERT INTO Categories (Name) VALUES (@Name)";
        await connection.ExecuteAsync(query, new { category.Name });
    }
}