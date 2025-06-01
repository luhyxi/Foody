using Foody.Shared.Kernel.Enums;
using Foody.Shared.Kernel.ValueObjects;
using Foody.Shared.Messaging.Bases;

namespace Foody.Food.API.Application.Restaurants.AddRestaurant;

public class AddRestaurantCommand : ICommand<Guid>
{
    public string RestaurantName ;
    public EntityStatus Status ;
    public DateTime CreationDate;
    public Score Score ;

    public AddRestaurantCommand(string restaurantName, EntityStatus status, DateTime creationDate, Score score)
    {
        RestaurantName = restaurantName;
        Status = status;
        CreationDate = creationDate;
        Score = score;
    }
}