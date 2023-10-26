using ComputerRepair.Domain.AggregateModels.PartnerAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.PartnerAggregate;

public sealed class Partner : AggregateRoot<PartnerId>
{
    private Partner(PartnerId id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }

    public static Partner Create(string title)
    {
        return new Partner(PartnerId.Create(), title);
    }
}
