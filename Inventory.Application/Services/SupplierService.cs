using System.Data.Common;
using FluentValidation;
using Inventory.Application.DTOs.Supplier;
using Inventory.Application.Extensions;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using MapsterMapper;

namespace Inventory.Application.Services;

public class SupplierService (
    ISupplierRepository supplierRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<CreateSupplierDto> createValidator,
    IValidator<UpdateSupplierDto> updateValidator
    ) : ISupplierService
{
    public async Task<SupplierResultDto> CreateSupplierAsync(CreateSupplierDto dto)
    {
        await createValidator.ValidateAndThrowAsync(dto);
        var supplier = Supplier.Create(dto.Name, dto.ContactName, dto.Email, dto.Phone);

        await supplierRepository.AddAsync(supplier);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<SupplierResultDto>(supplier);
    }

    public async Task<IEnumerable<SupplierResultDto>> GetAllSuppliersAsync()
    {
        var suppliers = await supplierRepository.GetAsync(tracked: false);
        return mapper.Map<IEnumerable<SupplierResultDto>>(suppliers);
    }

    public async Task<SupplierResultDto> GetSupplierByIdAsync(int id)
    {
        var supplier = await supplierRepository.GetByOrThrowAsync(id, "Supplier");
        return mapper.Map<SupplierResultDto>(supplier);

    }

    public async Task UpdateSupplierAsync(int id, UpdateSupplierDto dto)
    {
        await updateValidator.ValidateAndThrowAsync(dto);
        var supplier = await supplierRepository.GetByOrThrowAsync(id, "Supplier");
        
        supplier.Update(dto.Name, dto.ContactName, dto.Email, dto.Phone);
        supplierRepository.Update(supplier);
        await unitOfWork.SaveChangesAsync();


    }

    public async Task DeleteSupplierAsync(int id)
    {
        var supplier = await supplierRepository.GetByOrThrowAsync(id, "Supplier");
        
        supplierRepository.Remove(supplier);
        await unitOfWork.SaveChangesAsync();

    }
}