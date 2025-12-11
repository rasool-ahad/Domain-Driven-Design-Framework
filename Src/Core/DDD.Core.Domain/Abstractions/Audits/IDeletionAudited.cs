namespace DDD.Core.Domain.Abstractions.Audits;

public interface IDeletionAudited<TUserKey, TUser> where TUserKey : struct
{
    TUserKey? DeleterUserId { get; }

    DateTimeOffset? DeletedOnUtc { get; }

    TUser DeleterUser { get; }
}
