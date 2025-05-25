using Foody.Shared.Kernel.Enums;
using Foody.Shared.Kernel.ValueObjects;

namespace Foody.Shared.Kernel.Entities;

public class Restaurant(string name)
{
    string? UserName { get; set; } = name ?? throw new ArgumentNullException(nameof(name));
    EntityStatus Status { get; set; } = EntityStatus.Inactive;
    DateTime CreationDate{ get; set; } = DateTime.Now;
    Score Score { get; set; } = (Score)1f;
}