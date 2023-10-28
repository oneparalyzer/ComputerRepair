using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;

public sealed class RepairType : AggregateRoot<RepairTypeId>
{
    private RepairType(RepairTypeId id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }

    public static RepairType Create(string title)
    {
        return new RepairType(RepairTypeId.Create(), title);
    }

    public void Update(string newTitle)
    {
        Title = newTitle;
    }
}
