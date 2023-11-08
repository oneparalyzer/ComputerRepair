using ComputerRepair.Domain.AggregateModels.RoleAggregate.ValueObjects;

namespace ComputerRepair.Application.Common.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<bool> IsExistByIdAsync(RoleId roleId, CancellationToken cancellationToken = default);
}
