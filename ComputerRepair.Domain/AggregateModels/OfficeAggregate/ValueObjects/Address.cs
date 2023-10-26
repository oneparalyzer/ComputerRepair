

using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;

public sealed class Address : ValueObject
{
    private Address(string region, string city, string street, string home)
    {
        Region = region;
        City = city;
        Street = street;
        Home = home;
    }

    public string Region { get; }
    public string City { get; }
    public string Street { get; }
    public string Home { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Region;
        yield return City;
        yield return Street;
        yield return Home;
    }

    public static Address Create(string region, string city, string street, string home)
    {
        return new Address(region, city, street, home);
    }
}
