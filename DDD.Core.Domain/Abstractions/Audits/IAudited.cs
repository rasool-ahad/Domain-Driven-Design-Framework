namespace DDD.Core.Domain.Abstractions;

internal interface IAudited<TUserKey, TUser> : 
    ICreationAudited<TUserKey, TUser>, 
    IModificationAudited<TUserKey, TUser>
    where TUserKey : struct
{

}
