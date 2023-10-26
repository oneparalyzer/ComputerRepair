using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Price Create(decimal value)
    {
        return new Price(value);
    }
}
