using Foody.Shared.Messaging.ValueObjects;

namespace Foody.Food.API.Application.Restaurants;

public static class RestaurantErrors
{
    public static Error AlreadyExists(string name) => 
        new("Restaurant.AlreadyExists", $"Restaurant with name '{name}' already exists");
    
    public static Error NotFound(string name) => 
        new("Restaurant.NotFound", $"Restaurant with name '{name}' was not found");

    public static Error InvalidScore() => 
        new("Restaurant.InvalidScore", "Restaurant score must be between 1 and 10");

    public static Error InvalidStatus() => 
        new("Restaurant.InvalidStatus", "Invalid restaurant status provided");

    public static Error GeneralException(string message) => 
        new("Restaurant.GeneralException", $"An error occurred while adding the restaurant: {message}");

    
}