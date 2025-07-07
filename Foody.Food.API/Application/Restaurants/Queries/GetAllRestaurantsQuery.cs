using FluentValidation;
using Foody.Food.Domain.Repositories;
using Foody.Shared.Kernel.Entities;
using Foody.Shared.Messaging.Bases;
using Foody.Shared.Messaging.ValueObjects;

namespace Foody.Food.API.Application.Restaurants.Queries;

public class GetAllRestaurantsQuery : IQuery<List<Restaurant>>;

public class GetAllRestaurantsQueryHandler(
    IRestaurantRepository restaurantRepository,
    IValidator<GetAllRestaurantsQuery> validator,
    ILogger<GetAllRestaurantsQuery> logger) : IQueryHandler<GetAllRestaurantsQuery, List<Restaurant>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    private readonly IValidator<GetAllRestaurantsQuery> _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    private readonly ILogger<GetAllRestaurantsQuery> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public Task<Result<List<Restaurant>>> Handle(GetAllRestaurantsQuery command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}