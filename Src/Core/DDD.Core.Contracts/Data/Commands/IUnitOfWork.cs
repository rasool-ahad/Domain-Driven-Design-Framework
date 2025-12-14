namespace DDD.Core.Contracts.Data.Commands;

public interface IUnitOfWork
{
    void BeginTransaction();

    void CommitTransaction();

    void RollbackTransaction();

    int Commit();

    Task<int> CommitAsync();
}