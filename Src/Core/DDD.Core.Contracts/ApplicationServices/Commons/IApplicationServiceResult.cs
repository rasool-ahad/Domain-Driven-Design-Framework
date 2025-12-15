namespace DDD.Core.Contracts.ApplicationServices.Commons;

public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }

    ApplicationServiceStatus Status { get; set; }
}