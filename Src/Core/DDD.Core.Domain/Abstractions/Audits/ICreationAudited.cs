namespace DDD.Core.Domain.Abstractions.Audits;

public interface ICreationAudited<TUserKey, TUser> where TUserKey : struct
{
    TUserKey CreatorUserId { get; }

    TUser CreatorUser { get; }

    DateTimeOffset CreatedOnUtc { get; }
}
