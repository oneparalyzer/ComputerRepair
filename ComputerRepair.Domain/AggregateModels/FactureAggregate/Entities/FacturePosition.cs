using ComputerRepair.Domain.AggregateModels.FactureAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using ComputerRepair.Domain.Common.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.FactureAggregate.Entities;

public sealed class FacturePosition : Entity<FacturePositionId>
{
    private FacturePosition(
        FacturePositionId id, 
        SparePartId sparePartId, 
        int quantity,
        Price price,
        Price totalPrice) : base(id)
    {
        SparePartId = sparePartId;
        Quantity = quantity;
        Price = price;
        TotalPrice = totalPrice;
    }

    public SparePartId SparePartId { get; private set; }
    public int Quantity { get; private set; }
    public Price Price { get; private set; }
    public Price TotalPrice { get; private set; }

    public static FacturePosition Create(
        SparePartId sparePartId,
        int quantity,
        Price price)
    {
        decimal totalPrice = quantity * price.Value;

        return new FacturePosition(
            FacturePositionId.Create(), 
            sparePartId, 
            quantity, 
            price, 
            Price.Create(totalPrice));
    }
}
