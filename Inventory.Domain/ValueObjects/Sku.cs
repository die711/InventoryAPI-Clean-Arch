using System.Text.RegularExpressions;
using Inventory.Domain.Primitives;

namespace Inventory.Domain.ValueObjects;

public class Sku : ValueObject
{
    private const string SkuPattern = "^[a-zA-Z0-9]{8}$";
    public string Value { get; }

    private Sku(string value)
    {
        Value = value;
    }

    public static Sku Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, SkuPattern))
            throw new ArgumentException("El formato del SKU proporcionado no es valido.", nameof(value));

        return new Sku(value);

    }
    
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}