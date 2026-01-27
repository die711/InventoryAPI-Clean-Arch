namespace Inventory.Domain.Entites;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; set; }
    
    private Category(){}

    public static Category Create(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la categoria no puede estar vacio", nameof(name));

        return new Category { Name = name, Description = description };
    }


    public void Update(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la categoria no puede estar vacio", nameof(name));

        Name = name;
        Description = Description;


    }
    
}