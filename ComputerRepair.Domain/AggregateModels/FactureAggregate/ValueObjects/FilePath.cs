using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.FactureAggregate.ValueObjects;

public sealed class FilePath : ValueObject
{
    private FilePath(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static FilePath Create(string value)
    {
        return new FilePath(value);
    }
}
