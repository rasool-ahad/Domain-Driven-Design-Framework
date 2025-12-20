using DDD.Core.Contracts.ApplicationServices.Queries;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace DDD.Infra.Sql.EntityFramework.Queries;

public abstract class BaseQueryDbContext : DbContext
{
    public BaseQueryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges()
    {
        throw new NotSupportedException();
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new NotSupportedException();

    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();

    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();

    }
}


public static class QueryRepositoryExtensions
{
    public static async Task<PagedData<TResult>> ToPagedData<TEntity, TQuery, TResult>(this IQueryable<TEntity> entities, PageQuery<PagedData<TQuery>> query, Func<TEntity, TResult> selectFunc)
    {
        var result = new PagedData<TResult>
        {
            PageNumber = query.PageNumber,
            PageSize = query.PageSize
        };
        if (query.NeedTotalCount)
            result.TotalCount = await entities.CountAsync();

        if (!string.IsNullOrWhiteSpace(query.SortBy))
            entities = OrderByField(entities, query.SortBy, query.SortAscending);
        entities = entities.Skip(query.SkipCount).Take(query.PageSize);

        result.QueryResult = await entities.Select(
               c => selectFunc(c)).ToListAsync();
        return result;
    }

    private static IQueryable<T> OrderByField<T>(IQueryable<T> q, string SortField, bool Ascending)
    {
        var param = Expression.Parameter(typeof(T), "p");
        var prop = Expression.Property(param, SortField);
        var exp = Expression.Lambda(prop, param);
        string method = Ascending ? "OrderBy" : "OrderByDescending";
        Type[] types = [q.ElementType, exp.Body.Type];
        var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
        return q.Provider.CreateQuery<T>(mce);
    }

}