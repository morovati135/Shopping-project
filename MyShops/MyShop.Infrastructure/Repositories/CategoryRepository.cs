using System.Data;
using Dapper;
using MyShop.Domain.Models;
using MyShop.Domain.Interfaces;
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
        const string query = "SELECT * FROM Category";
        return await connection.QueryAsync<Category>(query);
    }

    public async Task AddCategoryAsync(Category category)
    {
        using var connection = _dbConnection.CreateConnection();
        const string query = "INSERT INTO Category (Name) VALUES (@Name)";
        await connection.ExecuteAsync(query, new { category.Name });
    }
}