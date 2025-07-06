using Dapper;
using Microsoft.Data.SqlClient;
using Foody.Shared.Kernel.Bases;
using Foody.Shared.Kernel.Entities;
using Foody.Shared.Kernel.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Foody.Food.Domain.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly string _connectionString;
    public IUnitOfWork UnitOfWork { get; init; }

    public RestaurantRepository(string connectionString, IUnitOfWork unitOfWork)
    {
        _connectionString = connectionString;
        UnitOfWork = unitOfWork;
    }

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public Restaurant Add(Restaurant restaurant)
    {
        using var connection = CreateConnection();
        var sql = @"
            INSERT INTO Restaurants (Id, Name, Description, Address, Phone, Email, CreatedDate, UpdatedDate) 
            VALUES (@Name, @Description, @Address, @Phone, @Email);
            SELECT * FROM Restaurants WHERE Id = @Id;";
        
        return connection.QuerySingle<Restaurant>(sql, restaurant);
    }

    public Restaurant Update(Restaurant restaurant)
    {
        using var connection = CreateConnection();
        var sql = @"
            UPDATE Restaurants 
            SET Name = @Name, Description = @Description, Address = @Address, 
                Phone = @Phone, Email = @Email, UpdatedDate = @UpdatedDate
            WHERE Id = @Id;
            SELECT * FROM Restaurants WHERE Id = @Id;";
        
        return connection.QuerySingle<Restaurant>(sql, restaurant);
    }

    public Task<Restaurant> FindByGuidAsync(string restaurantGuid)
    {
        if (!Guid.TryParse(restaurantGuid, out var guid))
            throw new ArgumentException("Invalid GUID format", nameof(restaurantGuid));
        
        return FindByGuidAsync(guid);
    }

    public async Task<Restaurant> AddAsync(Restaurant restaurant, CancellationToken cancellationToken = default)
    {
        using var connection = CreateConnection();
        var sql = @"
            INSERT INTO Restaurants (Id, Name, Description, Address, Phone, Email, CreatedDate, UpdatedDate) 
            VALUES (@Id, @Name, @Description, @Address, @Phone, @Email, @CreatedDate, @UpdatedDate);
            SELECT * FROM Restaurants WHERE Id = @Id;";
        
        return await connection.QuerySingleAsync<Restaurant>(sql, restaurant);
    }

    public async Task<Restaurant> UpdateAsync(Restaurant restaurant, CancellationToken cancellationToken = default)
    {
        using var connection = CreateConnection();
        var sql = @"
            UPDATE Restaurants 
            SET Name = @Name, Description = @Description, Address = @Address, 
                Phone = @Phone, Email = @Email, UpdatedDate = @UpdatedDate
            WHERE Id = @Id;
            SELECT * FROM Restaurants WHERE Id = @Id;";
        
        return await connection.QuerySingleAsync<Restaurant>(sql, restaurant);
    }

    public async Task<Restaurant?> FindByGuidAsync(Guid restaurantGuid, CancellationToken cancellationToken = default)
    {
        using var connection = CreateConnection();
        var sql = "SELECT * FROM Restaurants WHERE Id = @Id";
        
        return await connection.QuerySingleOrDefaultAsync<Restaurant>(sql, new { Id = restaurantGuid });
    }

    public async Task<Restaurant?> FindByNameAsync(string restaurantName, CancellationToken cancellationToken = default)
    {
        using var connection = CreateConnection();
        var sql = "SELECT * FROM Restaurants WHERE Name = @Name";
        
        return await connection.QuerySingleOrDefaultAsync<Restaurant>(sql, new { Name = restaurantName });
    }

    public async Task<bool> DeleteAsync(Guid restaurantGuid, CancellationToken cancellationToken = default)
    {
        using var connection = CreateConnection();
        var sql = "DELETE FROM Restaurants WHERE Id = @Id";
        
        var affectedRows = await connection.ExecuteAsync(sql, new { Id = restaurantGuid });
        return affectedRows > 0;
    }
}