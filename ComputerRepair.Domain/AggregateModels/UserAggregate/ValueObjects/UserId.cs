using ComputerRepair.Domain.Common.ValueObjects;

namespace ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;

public sealed class UserId : Id
{
    private UserId(Guid value) : base(value) { }

    public static UserId Create()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }
}
