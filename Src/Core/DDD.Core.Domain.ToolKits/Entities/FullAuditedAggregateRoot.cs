using DDD.Core.Domain.Abstractions.Audits;
using DDD.Core.Domain.Models.Entities;

namespace DDD.Core.Domain.ToolKits.Entities;

public abstract class FullAuditedAggregateRoot<TPrimaryKey, TUser, TUserKey> :
    AggregateRoot<TPrimaryKey>,
    IAuditedWithSoftDelete<TUserKey, TUser>
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

    public TUserKey? LastModifierUserId { get; protected set; }

    public TUser LastModifierUser { get; protected set; }

    public DateTimeOffset? UpdatedOnUtc { get; protected set; }

    public TUserKey? DeleterUserId { get; protected set; }

    public DateTimeOffset? DeletedOnUtc { get; protected set; }

    public TUser DeleterUser { get; protected set; }

    public bool IsDeleted { get; protected set; }
}