using FluentValidation;
using Inventory.Application.DTOs.Category;

namespace Inventory.Application.Validators.Category;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}