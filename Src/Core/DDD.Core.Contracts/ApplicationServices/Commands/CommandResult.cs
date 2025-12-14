using DDD.Core.Contracts.ApplicationServices.Commons;
using DDD.Core.Contracts.ApplicationServices.Queries;

namespace DDD.Core.Contracts.ApplicationServices.Commands;

public record CommandResult : ApplicationServiceResult
{
    protected CommandResult(bool isSuccess, ApplicationServiceErrorResult? error) : base(isSuccess, error)
    {
    }
}

public record CommandResult<TData> : ApplicationServiceResult<TData>
{
    private CommandResult(TData data) : base(data) { }

    private CommandResult(ApplicationServiceErrorResult error)
    : base(error)
    {
    }

    public static implicit operator CommandResult<TData>(TData data) => new(data);

    public static implicit operator CommandResult<TData>(ApplicationServiceErrorResult error) => new(error);
}