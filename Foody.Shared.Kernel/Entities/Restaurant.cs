using Foody.Shared.Kernel.Bases;
using Foody.Shared.Kernel.Enums;
using Foody.Shared.Kernel.ValueObjects;

namespace Foody.Shared.Kernel.Entities;

public class Restaurant() : EntityBase<Guid>, IAggregateRoot
{
    public string? RestaurantName { get; set; } =  "";
    public EntityStatus Status { get; set; } = EntityStatus.Inactive;
    public DateTime CreationDate{ get; set; } = DateTime.Now;
    public Score Score { get; set; } = (Score)1f;
}