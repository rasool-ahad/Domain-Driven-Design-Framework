namespace DDD.Core.Domain.Abstractions.Audits;

public interface ISoftDelete
{
    bool IsDeleted { get; protected set; }
}
