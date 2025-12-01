namespace DDD.Core.Domain.Abstractions;

public interface ISoftDelete
{
    bool IsDeleted { get; protected set; }
}
