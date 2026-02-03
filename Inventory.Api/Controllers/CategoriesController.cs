using Inventory.Application.DTOs.Category;
using Inventory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
    {
        var category = await categoryService.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto dto)
    {
        var category = await categoryService.CreateCategoryAsync(dto);
        return Ok(category);
    }


    [HttpPut]
    public async Task<IActionResult> Update(int id, UpdateCategoryDto dto)
    {
        await categoryService.UpdateCategoryAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
    
    
    
    
    
}