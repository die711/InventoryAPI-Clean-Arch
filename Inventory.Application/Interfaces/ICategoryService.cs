using Inventory.Application.DTOs.Category;

namespace Inventory.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResultDto>> GetAllCategoriesAsync();
    Task<CategoryResultDto> GetCategoryByIdAsync(int id);
    Task<CategoryResultDto> CreateCategoryAsync(CreateCategoryDto dto);
    Task UpdateCategoryAsync(int id, UpdateCategoryDto dto);
    Task DeleteCategoryAsync(int id);

}