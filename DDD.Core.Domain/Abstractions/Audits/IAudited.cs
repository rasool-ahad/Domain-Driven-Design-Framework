namespace DDD.Core.Domain.Abstractions.Audits;

public interface IAudited<TUserKey, TUser> : 
    ICreationAudited<TUserKey, TUser>, 
    IModificationAudited<TUserKey, TUser>
    where TUserKey : struct
{

}