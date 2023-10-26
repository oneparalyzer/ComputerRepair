using ComputerRepair.Domain.AggregateModels.Warehouses.ValueObjects;
using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.WarehouseAggregate.ValueObjects;

public sealed class SparePartWarehouseId : Id
{
    private SparePartWarehouseId(Guid value) : base(value) { }

    public static SparePartWarehouseId Create()
    {
        return new SparePartWarehouseId(Guid.NewGuid());
    }

    public static SparePartWarehouseId Create(Guid value)
    {
        return new SparePartWarehouseId(value);
    }
}
