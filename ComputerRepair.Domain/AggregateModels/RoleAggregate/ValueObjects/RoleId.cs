using ComputerRepair.Domain.Common.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.RoleAggregate.ValueObjects;

public sealed class RoleId : Id
{
    private RoleId(Guid value) : base(value) { }

    public static RoleId Create()
    {
        return new RoleId(Guid.NewGuid());
    }

    public static RoleId Create(Guid value)
    {
        return new RoleId(value);
    }
}
