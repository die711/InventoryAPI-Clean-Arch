using FluentValidation;
using Inventory.Application.DTOs.Category;
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

    public Task<CategoryResultDto> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryResultDto> CreateCategoryAsync(CreateCategoryDto dto)
    {
        await createValidator.ValidateAndThrowAsync(dto);
        var category = Category.Create(dto.Name, dto.Description);

        await categoryRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<CategoryResultDto>(category);
    }

    public Task UpdateCategoryAsync(int id, UpdateCategoryDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }
}