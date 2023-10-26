using ComputerRepair.Domain.AggregateModels.RoleAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.RoleAggregate;

public sealed class Role : AggregateRoot<RoleId>
{
    private Role(RoleId id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }

    public static Role Create(string title)
    {
        return new Role(RoleId.Create(), title);
    }
}
