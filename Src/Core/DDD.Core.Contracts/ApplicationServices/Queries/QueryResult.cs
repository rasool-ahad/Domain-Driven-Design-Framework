using DDD.Core.Contracts.ApplicationServices.Commons;

namespace DDD.Core.Contracts.ApplicationServices.Queries;

public sealed class QueryResult<TData> : ApplicationServiceResult
{
    public TData? _data;
    public TData? Data
    {
        get
        {
            return _data;
        }
    }
}