using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.WarehouseAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.WarehouseAggregate.Entities;

public sealed class SparePartWarehouse : AggregateRoot<SparePartWarehouseId>
{
    private SparePartWarehouse(
        SparePartWarehouseId id,
        SparePartId sparePartId,
        int quantity) : base(id)
    {
        SparePartId = sparePartId;
        Quantity = quantity;
    }

    public SparePartId SparePartId { get; private set; }
    public int Quantity { get; private set; }

    public static SparePartWarehouse Create(
        SparePartId sparePartId,
        int quantity)
    {
        return new SparePartWarehouse(
            SparePartWarehouseId.Create(),
            sparePartId,
            quantity);
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
}
