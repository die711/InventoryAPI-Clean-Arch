using Inventory.Application.DTOs.Product;

namespace Inventory.Application.Interfaces;

public interface IProductService
{
    Task<ProductResultDto> CreateProductAsync(CreateProductDto dto);
    Task<IEnumerable<ProductResultDto>> GetAllProductsAsync();
    Task<ProductResultDto> GetProductByIdAsync(int id);
    Task UpdateProductAsync(int id, UpdateProductDto dto);
    Task DeleteProductAsync(int id);
}