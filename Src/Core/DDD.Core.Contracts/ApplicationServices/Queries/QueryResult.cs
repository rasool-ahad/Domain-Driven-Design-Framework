using DDD.Core.Contracts.ApplicationServices.Commons;

namespace DDD.Core.Contracts.ApplicationServices.Queries;

public sealed record QueryResult<TData> : ApplicationServiceResult<TData>
{
    private QueryResult(TData data) : base(data) { }

    private QueryResult(ApplicationServiceErrorResult error)
    : base(error)
    {
    }

    public static implicit operator QueryResult<TData>(TData data) => new(data);

    public static implicit operator QueryResult<TData>(ApplicationServiceErrorResult error) => new(error);
}