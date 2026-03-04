using Inventory.Domain.Entites;

namespace Inventory.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdWithCategoryAsync(int id);
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();
}