using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;

public sealed class MeasureUnit : Enumeration
{
    private MeasureUnit(int id, string name) : base(id, name) { }

    public static readonly MeasureUnit Piece =new (1, "шт.");
}
