using System.Linq.Expressions;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class Repository<T>(InventoryDbContext context): IRepository<T> where T : class
{

    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (!tracked)
            query = query.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        return await query.ToListAsync();

    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}