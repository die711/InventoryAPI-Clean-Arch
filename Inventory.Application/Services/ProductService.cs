using FluentValidation;
using Inventory.Application.DTOs.Product;
using Inventory.Application.Extensions;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using Inventory.Domain.ValueObjects;
using MapsterMapper;

namespace Inventory.Application.Services;

public class ProductService (
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<CreateProductDto> createValidator,
    IValidator<UpdateProductDto> updateValidator
    ) 
    : IProductService
{
    public async Task<ProductResultDto> CreateProductAsync(CreateProductDto dto)
    {
        await createValidator.ValidateAndThrowAsync(dto);

        var sku = Sku.Create(dto.Sku);
        var product = Product.Create(dto.Name, sku, dto.Price, dto.CategoryId);

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<ProductResultDto>(product);
    }

    public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync()
    {
        var products = await productRepository.GetAllWithCategoryAsync();
        return mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public async Task<ProductResultDto> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetByIdWithCategoryAsync(id);
        if (product is null)
            throw new KeyNotFoundException($"Producto con el id {id} no encontrado");

        return mapper.Map<ProductResultDto>(product);
    }

    public async Task UpdateProductAsync(int id, UpdateProductDto dto)
    {
        await updateValidator.ValidateAndThrowAsync(dto);
        var product = await productRepository.GetByOrThrowAsync(id, "Product");
        
        product.Update(dto.Name, dto.Price, dto.CategoryId);
        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await productRepository.GetByOrThrowAsync(id, "Product");
        productRepository.Remove(product);
        await unitOfWork.SaveChangesAsync();
    }
}