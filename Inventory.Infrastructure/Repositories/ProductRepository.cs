using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class ProductRepository(InventoryDbContext context) : Repository<Product>(context), IProductRepository
{
    private readonly InventoryDbContext _context = context;

    public async Task<Product?> GetByIdWithCategoryAsync(int id)
    {
        return await _context.Products.Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

  
    
}