using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using BlogApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BlogApi.Infrastructure.Services;

public class GenericeRepository<T> : IGenericRepository<T> where T : class
{
    protected BlogDbContext context;
    internal DbSet<T> dbSet;
    protected readonly ILogger _logger;

    public GenericeRepository(BlogDbContext context , ILogger logger)
    {
        this.context = context;
        this.dbSet = context.Set<T>();
        this._logger = logger;
    }

    public virtual async Task<bool> Add(T entity)
    {
        try
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error", typeof(T));
            return false;
        }
        
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        try
        {
            return await dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error", typeof(T));
            return null;
        }
    }

    public virtual async Task<bool> Update(T entity)
    {
        try
        {
            dbSet.Update(entity);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error", typeof(T));
            return false;
        }
    }

    public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await dbSet.Where(predicate).ToListAsync();
    }


    public virtual async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<T> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    
}

