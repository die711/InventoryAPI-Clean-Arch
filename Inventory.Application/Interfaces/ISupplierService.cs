using Inventory.Application.DTOs.Supplier;

namespace Inventory.Application.Interfaces;

public interface ISupplierService
{
    Task<SupplierResultDto> CreateSupplierAsync(CreateSupplierDto dto);
    Task<IEnumerable<SupplierResultDto>> GetAllSuppliersAsync();
    Task<SupplierResultDto> GetSupplierByIdAsync(int id);
    Task UpdateSupplierAsync(int id, UpdateSupplierDto dto);
    Task DeleteSupplierAsync(int id);
}


