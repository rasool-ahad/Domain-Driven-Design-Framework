using DDD.Core.Contracts.ApplicationServices.Commons;

namespace DDD.Core.Contracts.ApplicationServices.Commands;

public class CommandResult : ApplicationServiceResult
{

}

public class CommandResult<TData> : CommandResult
{
    public TData? _data;

    public TData? Data => _data;
}