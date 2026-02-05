namespace Inventory.Domain.Entites;

public class Customer
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string? Email { get; private set; }
    public string? Phone { get; private set; }


    private Customer()
    {
    }

    public static Customer Create(string firstName, string lastName, string? email, string? phone)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("El nombre y el apellido son requeridos");

        return new Customer()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone
        };
    }

    public void Update(string firstName, string lastName, string? email, string? phone)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("El nombre y apellido son requeridos.");

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}