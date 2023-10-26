using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.FactureAggregate.ValueObjects;

public sealed class FactureId : Id
{
    private FactureId(Guid value) : base(value) { }

    public static FactureId Create()
    {
        return new FactureId(Guid.NewGuid());
    }

    public static FactureId Create(Guid value)
    {
        return new FactureId(value);
    }
}
