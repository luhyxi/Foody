using Foody.Shared.Kernel.Bases;

namespace Foody.Shared.Kernel.Interfaces;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}