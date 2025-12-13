namespace DDD.Core.Contracts.ApplicationServices.Commons;

public enum ApplicationServiceErrorType
{
    NotFound = 1,

    Conflict = 2,

    ValidationError = 3,

    InvalidDomainState = 4,

    UnSupported = 5,

    Exception = 6,
}