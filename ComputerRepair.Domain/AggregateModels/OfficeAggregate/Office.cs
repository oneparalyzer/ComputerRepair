using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.OfficeAggregate;

public sealed class Office : AggregateRoot<OfficeId>
{
    public Office(OfficeId id) : base(id) { }

    private Office(OfficeId id, string title, Address address) : base(id)
    {
        Title = title;
        Address = address;
    }

    public string Title { get; private set; }
    public Address Address { get; private set; }

    public static Office Create(string title, Address address)
    {
        return new Office(OfficeId.Create(), title, address);
    }

    public void Update(string newTitle, Address newAddress)
    {
        Title = newTitle;
        Address = newAddress;
    }
}
