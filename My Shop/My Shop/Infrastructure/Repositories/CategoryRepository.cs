using Microsoft.Data.SqlClient;

namespace My_Shop.Infrastructure.Repositories;

using System.Data;
using System.Data.SqlClient;
using Dapper;
using Core.Models;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task AddCategoryAsync(Category category);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly string _connectionString;

    public CategoryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        using var connection = CreateConnection();
        const string query = "SELECT * FROM Categories";
        return await connection.QueryAsync<Category>(query);
    }

    public async Task AddCategoryAsync(Category category)
    {
        using var connection = CreateConnection();
        const string query = "INSERT INTO Categories (Name) VALUES (@Name)";
        await connection.ExecuteAsync(query, new { category.Name });
    }
}
