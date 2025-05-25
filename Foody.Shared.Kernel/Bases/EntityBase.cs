namespace Foody.Shared.Kernel.Bases;


public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; } = default!;
}