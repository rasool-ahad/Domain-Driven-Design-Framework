using DDD.Core.Domain.Models.Entities;
using System.Linq.Expressions;

namespace DDD.Core.Contracts.Data.Commands;

public interface ICommandRepository<TEntity, TId> : IUnitOfWork
    where TEntity : AggregateRoot<TId>
     where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    void Delete(TId id);

    void DeleteGraph(TId id);

    void Delete(TEntity entity);

    void Insert(TEntity entity);


    Task InsertAsync(TEntity entity);

    TEntity Get(TId id);
    Task<TEntity> GetAsync(TId id);

    TEntity GetGraph(TId id);
    Task<TEntity> GetGraphAsync(TId id);

    bool Exists(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
}