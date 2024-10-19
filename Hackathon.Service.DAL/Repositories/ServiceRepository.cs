using Hackathon.Service.DAL.DbContexts;
using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hackathon.Service.DAL.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ServiceDbContext DbContext;

    public ServiceRepository(ServiceDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public IQueryable<TEntity> AsQueryable<TEntity>(bool includeAllTenants = false) where TEntity : class, IBaseEntity
    {
        if (includeAllTenants)
            return DbContext.Set<TEntity>().IgnoreQueryFilters();

        return DbContext.Set<TEntity>();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IBaseEntity
    {
        return DbContext.Set<TEntity>().Where(expression);
    }

    public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await DbContext.SaveChangesAsync();
    }

    public void Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public IQueryable<TEntity> Include<TEntity>(string navigationPropertyPath) where TEntity : class, IBaseEntity
    {
        return DbContext.Set<TEntity>().Include(navigationPropertyPath);
    }

    public async Task InsertBulkAsync<TEntity>(List<TEntity> entities) where TEntity : class, IBaseEntity
    {
        foreach (TEntity entity in entities)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
        }
    }

    public IQueryable<TEntity> FromSql<TEntity>(FormattableString sql) where TEntity : class, IBaseEntity
    {
        return DbContext.Set<TEntity>().FromSql(sql);
    }

    public IQueryable<TEntity> FromSqlRaw<TEntity>(string sql, params object[] parameters) where TEntity : class, IBaseEntity
    {
        return DbContext.Set<TEntity>().FromSqlRaw(sql, parameters);
    }

    public UserInfo? GetUserInfo()
    {
        return DbContext.UserInfo;
    }
}
