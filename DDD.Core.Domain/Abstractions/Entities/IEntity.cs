using System.Security.Principal;

namespace DDD.Core.Domain.Abstractions.Entities;

public interface IEntity<TPrimaryKey> where TPrimaryKey : struct
{
    TPrimaryKey Id { get; }
}
