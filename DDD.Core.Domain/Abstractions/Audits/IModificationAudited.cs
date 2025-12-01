namespace DDD.Core.Domain.Abstractions;

public interface IModificationAudited<TUserKey, TUser> where TUserKey : struct
{
    TUserKey? LastModifierUserId { get; protected set; }

    TUser LastModifierUser { get; protected set; }

    DateTimeOffset? UpdatedOnUtc { get; protected set; }
}
