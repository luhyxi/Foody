using Foody.Food.API.Application.Restaurants.Commands.AddRestaurant;
using Foody.Shared.Messaging.Bases;

namespace Foody.Web.Swagger.Endpoints;

public static class RestaurantsEndpoints
{
    public static RouteGroupBuilder MapRestaurantsApi(this RouteGroupBuilder group)
    {
        group.MapPost("/", AddRestaurant);
        return group;
    }
    
    private static async Task<IResult> AddRestaurant(
        AddRestaurantCommand command,
        ICommandHandler<AddRestaurantCommand, Guid> handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(command, cancellationToken);
        
        return !result.IsFailure 
            ? Results.Created($"/restaurants/{result.Value}", result.Value)
            : Results.BadRequest(result.Error);
    }
}