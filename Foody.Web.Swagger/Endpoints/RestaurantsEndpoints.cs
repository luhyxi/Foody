using Foody.Food.API.Application.Restaurants.Commands.AddRestaurant;
using Foody.Food.API.Application.Restaurants.Queries;
using Foody.Shared.Kernel.Entities;
using Foody.Shared.Messaging.Bases;
using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Swagger.Endpoints;

public static class RestaurantsEndpoints
{
    public static RouteGroupBuilder MapRestaurantsApi(this RouteGroupBuilder group)
    {
        group.MapPost("/restaurants", AddRestaurant);
        group.MapGet("/restaurants/search", GetAllRestaurants);
        return group;
    }
    
    private static async Task<IResult> AddRestaurant(
        [FromBody] AddRestaurantCommand command,
        [FromServices] ICommandHandler<AddRestaurantCommand, Guid> handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(command, cancellationToken);
        
        return result.IsSuccess 
            ? Results.Created($"/restaurants/{result.Value}", result.Value)
            : Results.BadRequest(result.Error);
    }
    
    private static async Task<IResult> GetAllRestaurants(
        [AsParameters] GetAllRestaurantsQuery query,
        [FromServices] IQueryHandler<GetAllRestaurantsQuery, List<Restaurant>> handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(query, cancellationToken);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }
}