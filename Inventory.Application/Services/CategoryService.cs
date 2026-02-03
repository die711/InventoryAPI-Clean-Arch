using FluentValidation;
using Inventory.Application.DTOs.Category;
using Inventory.Application.Extensions;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using MapsterMapper;

namespace Inventory.Application.Services;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<CreateCategoryDto> createValidator,
    IValidator<UpdateCategoryDto> updateValidator
    ) : ICategoryService
{
    public async Task<IEnumerable<CategoryResultDto>> GetAllCategoriesAsync()
    {
        var categories = await categoryRepository.GetAsync(tracked: false);
        return mapper.Map<IEnumerable<CategoryResultDto>>(categories);
    }

    public async Task<CategoryResultDto> GetCategoryByIdAsync(int id)
    {
        var category = await categoryRepository.GetByOrThrowAsync(id, "Category");
        return mapper.Map<CategoryResultDto>(category);
    }

    public async Task<CategoryResultDto> CreateCategoryAsync(CreateCategoryDto dto)
    {
        await createValidator.ValidateAndThrowAsync(dto);
        var category = Category.Create(dto.Name, dto.Description);

        await categoryRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<CategoryResultDto>(category);
    }

    public async Task UpdateCategoryAsync(int id, UpdateCategoryDto dto)
    {
        await updateValidator.ValidateAndThrowAsync(dto);
        var category = await categoryRepository.GetByOrThrowAsync(id, "Category");
        
        category.Update(dto.Name, dto.Description);
        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync();

    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await categoryRepository.GetByOrThrowAsync(id, "Category");
        categoryRepository.Remove(category);
        await unitOfWork.SaveChangesAsync();
    }
}