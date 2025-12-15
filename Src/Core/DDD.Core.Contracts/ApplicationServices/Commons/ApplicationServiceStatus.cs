namespace DDD.Core.Contracts.ApplicationServices.Commons;

public enum ApplicationServiceStatus
{
    Ok = 1,

    NotFound = 2,

    ValidationError = 3,

    InvalidDomainState = 4,

    Forbiden = 5,

    Exception = 100,
}