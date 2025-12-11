using DDD.Core.Domain.Abstractions.Audits;
using DDD.Core.Domain.Models.Entities;

namespace DDD.Core.Domain.ToolKits.Entities;

public abstract class ModificationAuditedAggregateRoot<TPrimaryKey, TUser, TUserKey> :
    AggregateRoot<TPrimaryKey>,
    IModificationAudited<TUserKey, TUser>
    where TPrimaryKey : struct,
        IComparable,
        IComparable<TPrimaryKey>,
        IConvertible,
        IEquatable<TPrimaryKey>,
        IFormattable
    where TUser : class
    where TUserKey : struct
{
    public TUserKey? LastModifierUserId { get; protected set; }

    public TUser LastModifierUser { get; protected set; }

    public DateTimeOffset? UpdatedOnUtc { get; protected set; }
}