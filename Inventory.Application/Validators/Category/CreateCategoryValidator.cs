using FluentValidation;
using Inventory.Application.DTOs.Category;

namespace Inventory.Application.Validators.Category;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}