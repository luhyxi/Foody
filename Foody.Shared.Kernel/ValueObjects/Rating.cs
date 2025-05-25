namespace Foody.Shared.Kernel.ValueObjects;

public readonly record struct Rating(
    Guid Id,
    DateTime CreationDate, 
    Guid UserIdAssociated,
    Guid RestaurantIdAssociated,
    Score ScoreGiven);