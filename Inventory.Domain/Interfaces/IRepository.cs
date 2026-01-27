using System.Linq.Expressions;

namespace Inventory.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    
    
    
    
}