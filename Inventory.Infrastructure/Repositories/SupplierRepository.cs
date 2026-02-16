using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories;

public class SupplierRepository(InventoryDbContext context) : Repository<Supplier>(context), ISupplierRepository
{
    
}