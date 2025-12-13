namespace DDD.Core.Contracts.ApplicationServices.Commons;

public interface IApplicationServiceResult
{
    public bool IsSuccess { get; }

    public ApplicationServiceErrorResult? Error { get; }
}