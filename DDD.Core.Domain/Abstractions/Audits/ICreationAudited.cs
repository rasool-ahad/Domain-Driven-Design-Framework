namespace DDD.Core.Domain.Abstractions;

public interface ICreationAudited<TUserKey, TUser> where TUserKey : struct
{
    TUserKey CreatorUserId { get; protected set; }

    TUser CreatorUser { get; protected set; }

    DateTimeOffset CreatedOnUtc { get; protected set; }
}
