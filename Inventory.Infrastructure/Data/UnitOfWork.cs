using Inventory.Domain.Interfaces;

namespace Inventory.Infrastructure.Data;

public class UnitOfWork(InventoryDbContext context): IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    } 
    
    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
    
}