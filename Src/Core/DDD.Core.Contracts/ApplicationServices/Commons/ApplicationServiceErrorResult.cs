namespace DDD.Core.Contracts.ApplicationServices.Commons;

public record ApplicationServiceErrorResult(string Id, ApplicationServiceErrorType Type, string Description, IEnumerable<string>? Messages = null);

public static class ApplicationServiceErrors
{
    public static ApplicationServiceErrorResult AccountNotFound(string description, IEnumerable<string> messages) =>
        new("AccountNotFound", ApplicationServiceErrorType.NotFound, description, messages);

    public static ApplicationServiceErrorResult ValidationError(string description, IEnumerable<string> messages) =>
        new("AccountNotFound", ApplicationServiceErrorType.ValidationError, description, messages);

    public static ApplicationServiceErrorResult Conflict(string description, IEnumerable<string> messages) =>
        new("AccountNotFound", ApplicationServiceErrorType.Conflict, description, messages);

    public static ApplicationServiceErrorResult InvalidDomainState(string description, IEnumerable<string> messages) =>
        new("AccountNotFound", ApplicationServiceErrorType.InvalidDomainState, description, messages);

    public static ApplicationServiceErrorResult UnSupported(string description, IEnumerable<string> messages) =>
        new("AccountNotFound", ApplicationServiceErrorType.UnSupported, description, messages);
    public static ApplicationServiceErrorResult Exception(string description, IEnumerable<string> messages) =>
        new("AccountNotFound", ApplicationServiceErrorType.Exception, description, messages);
}