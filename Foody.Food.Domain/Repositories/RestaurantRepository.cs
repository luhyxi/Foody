using Foody.Shared.Kernel.Entities;
using Foody.Shared.Kernel.Interfaces;

namespace Foody.Food.Domain.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    public IUnitOfWork UnitOfWork { get; }
    
    public Restaurant Add(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }

    public Restaurant Update(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant> FindByGuidAsync(string restaurantGuid)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant> FindByRestaurantNameAsync(int restaurantName)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant> AddAsync(Restaurant restaurant, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant> UpdateAsync(Restaurant restaurant, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant?> FindByGuidAsync(Guid restaurantGuid, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant?> FindByNameAsync(string restaurantName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid restaurantGuid, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}