using Hackathon.Service.DAL.Models;
using System.Linq.Expressions;

namespace Hackathon.Service.DAL.Interfaces;

public interface IServiceRepository
{
    IQueryable<TEntity> AsQueryable<TEntity>(bool includeAllTenants = false)
        where TEntity : class, IBaseEntity;

    IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IBaseEntity;

    Task InsertAsync<TEntity>(TEntity entity)
        where TEntity : class, IBaseEntity;

    void Update<TEntity>(TEntity entity)
        where TEntity : class, IBaseEntity;

    void Delete<TEntity>(TEntity entity)
        where TEntity : class, IBaseEntity;

    IQueryable<TEntity> Include<TEntity>(string navigationPropertyPath)
        where TEntity : class, IBaseEntity;

    IQueryable<TEntity> FromSql<TEntity>(FormattableString sql) where TEntity : class, IBaseEntity;

    IQueryable<TEntity> FromSqlRaw<TEntity>(string sql, params object[] parameters) where TEntity : class, IBaseEntity;

    Task SaveChangesAsync();

    public UserInfo? GetUserInfo();
}
