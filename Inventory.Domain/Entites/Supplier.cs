namespace Inventory.Domain.Entites;

public class Supplier
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? ContactName { get; private set; }
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
    
    private Supplier(){}


    public static Supplier Create(string name, string? contactName, string? email, string? phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del proveedor es requerido", nameof(name));

        return new Supplier
        {
            Name = name,
            ContactName = contactName,
            Email = email,
            Phone = phone
        };
    }


    public void Update(string name, string? contactName, string? email, string? phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del proveedor es requerido.", nameof(name));

        Name = name;
        ContactName = contactName;
        Email = email;
        Phone = phone;
    }
    
}