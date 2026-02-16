using FluentValidation;
using Inventory.Application.DTOs.Supplier;

namespace Inventory.Application.Validators.Supplier;

public class CreateSupplierValidator : AbstractValidator<CreateSupplierDto>
{
    public CreateSupplierValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ContactName).MaximumLength(50);
        RuleFor(x => x.Email).MaximumLength(50);
        RuleFor(x => x.Phone).MaximumLength(20);
    }
}