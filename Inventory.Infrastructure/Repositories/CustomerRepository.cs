using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories;

public class CustomerRepository(InventoryDbContext context) : Repository<Customer>(context), ICustomerRepository
{
    
}