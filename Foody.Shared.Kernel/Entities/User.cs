using Foody.Shared.Kernel.Bases;
using Foody.Shared.Kernel.Enums;

namespace Foody.Shared.Kernel.Entities;

public sealed class User(string name):EntityBase<Guid>
{
    string? UserName { get; set; } = name ?? throw new ArgumentNullException(nameof(name));
    EntityStatus Status { get; set; } = EntityStatus.Inactive;
    DateTime CreationDate{ get; set; } = DateTime.Now;
    UserRanking Rankings { get; set; } = UserRanking.Newbie;
}