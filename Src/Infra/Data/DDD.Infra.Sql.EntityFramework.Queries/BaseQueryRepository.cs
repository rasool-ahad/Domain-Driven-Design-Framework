using DDD.Core.Contracts.Data.Queries;

namespace DDD.Infra.Sql.EntityFramework.Queries;

public class BaseQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}