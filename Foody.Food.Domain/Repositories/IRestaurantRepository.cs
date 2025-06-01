using Foody.Shared.Kernel.Entities;
using Foody.Shared.Kernel.Interfaces;

namespace Foody.Food.Domain.Repositories;

public interface IRestaurantRepository : IRepository<Restaurant>
{
    Task<Restaurant> AddAsync(Restaurant restaurant, CancellationToken cancellationToken = default);
    Task<Restaurant> UpdateAsync(Restaurant restaurant, CancellationToken cancellationToken = default);
    Task<Restaurant?> FindByGuidAsync(Guid restaurantGuid, CancellationToken cancellationToken = default);
    Task<Restaurant?> FindByNameAsync(string restaurantName, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid restaurantGuid, CancellationToken cancellationToken = default);
}