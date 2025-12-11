namespace DDD.Core.Domain.Abstractions.Audits;

public interface IModificationAudited<TUserKey, TUser> where TUserKey : struct
{
    TUserKey? LastModifierUserId { get; }

    TUser LastModifierUser { get; }

    DateTimeOffset? UpdatedOnUtc { get; }
}
