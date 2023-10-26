using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;

public sealed class RepairTypeId : Id
{
    private RepairTypeId(Guid value) : base(value) { }

    public static RepairTypeId Create()
    {
        return new RepairTypeId(Guid.NewGuid());
    }

    public static RepairTypeId Create(Guid value)
    {
        return new RepairTypeId(value);
    }
}
