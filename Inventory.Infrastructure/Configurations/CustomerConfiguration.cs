using Inventory.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Email).HasMaxLength(50);
        builder.Property(c => c.Phone).HasMaxLength(50);
    }
}