using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories;

public class CategoryRepository(InventoryDbContext context) : Repository<Category>(context), ICategoryRepository
{
    
}