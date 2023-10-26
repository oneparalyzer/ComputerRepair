using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.PartnerAggregate.ValueObjects;

public sealed class PartnerId : Id
{
    private PartnerId(Guid value) : base(value) { }

    public static PartnerId Create()
    {
        return new PartnerId(Guid.NewGuid());   
    }

    public static PartnerId Create(Guid value)
    {
        return new PartnerId(value);
    }
}
