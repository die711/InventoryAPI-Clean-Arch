using Inventory.Application.DTOs.Supplier;
using Inventory.Domain.Entites;
using Mapster;

namespace Inventory.Application.Mappings;

public class SupplierProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Supplier, SupplierResultDto>()
            .Map(dest => dest.Contact, src => src.ContactName);
    }
}