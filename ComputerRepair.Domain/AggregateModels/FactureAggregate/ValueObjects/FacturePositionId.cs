using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.FactureAggregate.ValueObjects;

public sealed class FacturePositionId : Id
{
    private FacturePositionId(Guid value) : base(value) { }

    public static FacturePositionId Create()
    {
        return new FacturePositionId(Guid.NewGuid());
    }

    public static FacturePositionId Create(Guid value)
    {
        return new FacturePositionId(value);
    }
}
