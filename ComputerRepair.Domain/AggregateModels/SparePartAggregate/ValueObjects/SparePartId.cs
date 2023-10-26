using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;

public sealed class SparePartId : Id
{
    private SparePartId(Guid value) : base(value) { }

    public static SparePartId Create()
    {
        return new SparePartId(Guid.NewGuid());
    }

    public static SparePartId Create(Guid value)
    {
        return new SparePartId(value);
    }
}
