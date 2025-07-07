using Foody.Shared.Messaging.ValueObjects;

namespace Foody.Shared.Messaging.Bases;

public interface IQueryHandler<in TQuery> where TQuery : IQuery
{
    Task<Result> Handle(TQuery query, CancellationToken cancellationToken = default);
}

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken = default);
}