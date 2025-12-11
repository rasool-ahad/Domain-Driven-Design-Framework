using DDD.Core.Domain.Abstractions.Audits;
using DDD.Core.Domain.Models.Entities;

namespace DDD.Core.Domain.ToolKits.Entities;

public abstract class CreationAuditedAggregateRoot<TPrimaryKey, TUser, TUserKey> :
    AggregateRoot<TPrimaryKey>,
    ICreationAudited<TUserKey, TUser>
    where TPrimaryKey : struct,
        IComparable,
        IComparable<TPrimaryKey>,
        IConvertible,
        IEquatable<TPrimaryKey>,
        IFormattable
    where TUser : class
    where TUserKey : struct
{
    public TUserKey CreatorUserId { get; protected set; }

    public TUser CreatorUser { get; protected set; }

    public DateTimeOffset CreatedOnUtc { get; protected set; }
}
