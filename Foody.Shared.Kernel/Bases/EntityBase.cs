using Foody.Shared.Kernel.Enums;

namespace Foody.Shared.Kernel.Bases;


public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; } = default!;
    public DateTime CreationDate{ get; set; } = DateTime.Now;
    public EntityStatus Status { get; set; } = EntityStatus.Inactive;
    public DateTime UpdatedDate { get; set; }
}