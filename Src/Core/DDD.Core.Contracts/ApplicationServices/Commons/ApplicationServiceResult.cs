namespace DDD.Core.Contracts.ApplicationServices.Commons;

public record ApplicationServiceResult : IApplicationServiceResult
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public ApplicationServiceErrorResult? Error { get; }

    protected ApplicationServiceResult(bool isSuccess, ApplicationServiceErrorResult? error)
    {
        if (isSuccess && error is not null)
            throw new InvalidOperationException();

        if (!isSuccess && error is null)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }
}

public record ApplicationServiceResult<T> : ApplicationServiceResult
{
    private readonly T? _value;

    public T Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException("No value for failure result.");

    protected ApplicationServiceResult(T value)
        : base(true, null)
    {
        _value = value;
    }

    protected ApplicationServiceResult(ApplicationServiceErrorResult error)
        : base(false, error)
    {
        _value = default;
    }

    public static ApplicationServiceResult<T> Success(T value) => new(value);

    public static ApplicationServiceResult<T> Failure(ApplicationServiceErrorResult error) => new(error);

    public static implicit operator ApplicationServiceResult<T>(T value)
        => Success(value);

    public static implicit operator ApplicationServiceResult<T>(ApplicationServiceErrorResult error)
        => Failure(error);
}