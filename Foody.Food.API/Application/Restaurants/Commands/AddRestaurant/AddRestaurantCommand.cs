using FluentValidation;
using Foody.Food.Domain.Repositories;
using Foody.Shared.Kernel.Entities;
using Foody.Shared.Kernel.Enums;
using Foody.Shared.Kernel.ValueObjects;
using Foody.Shared.Messaging.Bases;
using Foody.Shared.Messaging.ValueObjects;

namespace Foody.Food.API.Application.Restaurants.Commands.AddRestaurant;

public class AddRestaurantCommand(
    string restaurantName, 
    EntityStatus status, 
    DateTime creationDate, 
    Score score) : ICommand<Guid>
{
    public string RestaurantName = restaurantName;
    public EntityStatus Status = status;
    public DateTime CreationDate = creationDate;
    public Score Score = score;
}
public class AddRestaurantHandler(
    IRestaurantRepository restaurantRepository,
    IValidator<AddRestaurantCommand> validator,
    ILogger<AddRestaurantHandler> logger)
    : ICommandHandler<AddRestaurantCommand, Guid>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    private readonly IValidator<AddRestaurantCommand> _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    private readonly ILogger<AddRestaurantHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<Result<Guid>> Handle(AddRestaurantCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for restaurant '{Name}': {Errors}", command.RestaurantName, validationResult.Errors);
                return (Result<Guid>)RestaurantErrors.GeneralException("validation error");
            }
            
            var existingRestaurant = await _restaurantRepository.FindByNameAsync(command.RestaurantName, cancellationToken);
            if (existingRestaurant is not null)
            {
                _logger.LogWarning("Restaurant with name '{Name}' already exists", command.RestaurantName);
                return (Result<Guid>)RestaurantErrors.AlreadyExists(command.RestaurantName);
            }

            var restaurant = new Restaurant
            {
                Id = Guid.NewGuid(),
                RestaurantName = command.RestaurantName,
                Status = command.Status,
                CreationDate = command.CreationDate,
                Score = command.Score,
            };

            await _restaurantRepository.AddAsync(restaurant, cancellationToken);

            _logger.LogInformation("Successfully added restaurant '{Name}' with ID {Id}", restaurant.RestaurantName, restaurant.Id);
            
            return restaurant.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding restaurant '{Name}'", command.RestaurantName);
            return (Result<Guid>)RestaurantErrors.GeneralException(ex.Message);
        }
    }
}