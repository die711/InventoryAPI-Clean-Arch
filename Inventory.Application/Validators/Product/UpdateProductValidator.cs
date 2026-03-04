using FluentValidation;
using Inventory.Application.DTOs.Product;

namespace Inventory.Application.Validators.Product;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{

    public UpdateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
    }
    
}