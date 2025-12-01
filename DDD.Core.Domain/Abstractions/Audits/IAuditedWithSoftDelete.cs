namespace DDD.Core.Domain.Abstractions;

internal interface IAuditedWithSoftDelete<TUserKey, TUser> :
    ICreationAudited<TUserKey, TUser>,
    IModificationAudited<TUserKey, TUser>,
    IDeletionAudited<TUserKey, TUser>,
    ISoftDelete
    where TUserKey : struct
{

}