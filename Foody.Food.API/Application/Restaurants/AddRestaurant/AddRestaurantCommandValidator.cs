using FluentValidation;
using Foody.Shared.Messaging.Bases;

namespace Foody.Food.API.Application.Restaurants.AddRestaurant;

public class AddRestaurantCommandValidator : AbstractValidator<AddRestaurantCommand>
{
    public AddRestaurantCommandValidator()
    {
        RuleFor(x => x.RestaurantName).NotEmpty();
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.CreationDate).NotEmpty();
    }
}