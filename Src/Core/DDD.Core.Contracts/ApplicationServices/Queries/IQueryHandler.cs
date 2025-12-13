namespace DDD.Core.Contracts.ApplicationServices.Queries;

public interface IQueryHandler<TQuery, TData> where TQuery : IQuery<TData>
{
    Task<QueryResult<TData>> Handle(TQuery request);
}