namespace Inventory.Domain.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();
    
    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);

    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValuesAreEqual(other);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate(0, (hash, objHash) => HashCode.Combine(hash, objHash));
    }

    public static bool operator ==(ValueObject? a, ValueObject b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);

    }

    public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);


    public bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

}