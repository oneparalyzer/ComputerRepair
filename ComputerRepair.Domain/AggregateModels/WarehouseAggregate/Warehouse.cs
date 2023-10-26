using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.WarehouseAggregate.Entities;
using ComputerRepair.Domain.AggregateModels.Warehouses.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.Warehouses;

public sealed class Warehouse : AggregateRoot<WarehouseId>
{
    private readonly List<SparePartWarehouse> _spareParts = new();

    private Warehouse(WarehouseId id) : base(id)
    {
    }

    public IReadOnlyList<SparePartWarehouse> SpareParts => _spareParts.AsReadOnly();

    public Result AddSparePart(SparePartId sparePartId, int quantity)
    {
        SparePartWarehouse? sparePartWarehouse = _spareParts
            .FirstOrDefault(x =>
                x.SparePartId == sparePartId);
        if (sparePartWarehouse is null)
        {
            _spareParts.Add(SparePartWarehouse.Create(sparePartId, quantity));
            return Result.Success();
        }

        sparePartWarehouse.AddQuantity(quantity);

        return Result.Success();
    }
}
