using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.SparePartAggregate;

public sealed class SparePart : AggregateRoot<SparePartId>
{
    private SparePart(SparePartId id) : base(id) { }

    private SparePart(SparePartId id, string title, MeasureUnit measureUnit) : base(id)
    {
        Title = title;
        MeasureUnit = measureUnit;
    }

    public string Title { get; }
    public MeasureUnit MeasureUnit { get; }

    public static SparePart Create(string title, MeasureUnit measureUnit)
    {
        return new SparePart(SparePartId.Create(), title, measureUnit);
    }
}
