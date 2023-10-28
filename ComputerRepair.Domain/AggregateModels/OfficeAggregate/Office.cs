using ComputerRepair.Domain.AggregateModels.OfficeAggregate.Enums;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.OfficeAggregate;

public sealed class Office : AggregateRoot<OfficeId>
{
    private Office(OfficeId id) : base(id) { }

    private Office(OfficeId id, string title, Address address, OfficeType officeType) : base(id)
    {
        Title = title;
        Address = address;
        OfficeType = officeType;
    }

    public string Title { get; private set; }
    public Address Address { get; private set; }
    public OfficeType OfficeType { get; private set; }

    public static Office Create(string title, Address address, OfficeType officeType)
    {
        return new Office(OfficeId.Create(), title, address, officeType);
    }

    public void Update(string newTitle, Address newAddress)
    {
        Title = newTitle;
        Address = newAddress;
    }

    public bool CanProvideServices()
    {
        return OfficeType == OfficeType.ForProvideServices;
    }
}
