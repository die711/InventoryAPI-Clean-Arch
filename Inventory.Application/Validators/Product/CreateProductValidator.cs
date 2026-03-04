using FluentValidation;
using Inventory.Application.DTOs.Product;

namespace Inventory.Application.Validators.Product;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Sku).NotEmpty().WithMessage("El SKU es requerido").Length(8)
            .WithMessage("El SKU debe tener exactamente 8 caracteres.");
        
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
    }
}