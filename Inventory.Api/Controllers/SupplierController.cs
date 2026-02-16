using Inventory.Application.DTOs.Supplier;
using Inventory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController(ISupplierService supplierService): ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await supplierService.GetAllSuppliersAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var supplier = await supplierService.GetSupplierByIdAsync(id);
        return Ok(supplier);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSupplierDto dto)
    {
        var newSupplier = await supplierService.CreateSupplierAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = newSupplier.Id }, newSupplier);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateSupplierDto dto)
    {
        await supplierService.UpdateSupplierAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await supplierService.DeleteSupplierAsync(id);
        return NoContent();
    }
    
}