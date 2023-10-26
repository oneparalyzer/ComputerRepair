using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;

public sealed class RepairType : AggregateRoot<RepairTypeId>
{
    private RepairType(RepairTypeId id, string title, OfficeId officeId) : base(id)
    {
        Title = title;
        OfficeId = officeId;
    }

    public string Title { get; private set; }
    public OfficeId OfficeId { get; }

    public static RepairType Create(string title, OfficeId officeId)
    {
        return new RepairType(RepairTypeId.Create(), title, officeId);
    }

    public void Update(string newTitle)
    {
        Title = newTitle;
    }
}
