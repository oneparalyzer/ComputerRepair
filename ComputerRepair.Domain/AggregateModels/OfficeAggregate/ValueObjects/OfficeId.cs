using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;

public sealed class OfficeId : Id
{
    private OfficeId(Guid value) : base(value) { }

    public static OfficeId Create()
    {
        return new OfficeId(Guid.NewGuid());
    }

    public static OfficeId Create(Guid value)
    {
        return new OfficeId(value);
    }
}
