using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.Warehouses.ValueObjects;

public sealed class WarehouseId : Id
{
    private WarehouseId(Guid value) : base(value) { }

    public static WarehouseId Create()
    {
        return new WarehouseId(Guid.NewGuid());
    }

    public static WarehouseId Create(Guid value)
    {
        return new WarehouseId(value);
    }
}
