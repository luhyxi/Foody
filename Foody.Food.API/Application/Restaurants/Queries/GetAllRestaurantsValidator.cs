using FluentValidation;

namespace Foody.Food.API.Application.Restaurants.Queries;

public class GetAllRestaurantsValidator : AbstractValidator<GetAllRestaurantsQuery>
{
    public GetAllRestaurantsValidator()
    {
    }
}