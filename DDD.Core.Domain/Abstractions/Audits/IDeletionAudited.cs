namespace DDD.Core.Domain.Abstractions;

public interface IDeletionAudited<TUserKey, TUser> where TUserKey : struct
{
    TUserKey? DeleterUserId { get; protected set; }

    DateTimeOffset? DeletedOnUtc { get; set; }

    TUser DeleterUser { get; set; }
}
