using Inventory.Domain.ValueObjects;

namespace Inventory.Domain.Entites;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Sku Sku { get; private set; }
    public decimal Price { get; private set; }
    public int CategoryId { get; private set; }
    public virtual Category Category { get; private set; } = null!;

    private Product()
    {
        
    }
    
    public static Product Create(string name, Sku sku, decimal price, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del producto no puede estar vacio.", nameof(name));

        if (price <= 0)
            throw new ArgumentException("El precio debe ser un valor positivo.", nameof(price));

        return new Product
        {
            Name = name,
            Sku = sku,
            Price = price,
            CategoryId = categoryId
        };
    }

    public void Update(string name, decimal price, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del producto no puede estar vacio.", nameof(name));

        if (price <= 0)
            throw new ArgumentException("El precio debe ser un valor positivo.", nameof(price));

        Name = name;
        Price = price;
        CategoryId = categoryId;

    }
    

}