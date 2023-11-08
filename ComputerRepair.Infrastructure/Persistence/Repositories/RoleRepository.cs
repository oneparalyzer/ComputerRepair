using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.RoleAggregate.ValueObjects;
using ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;
using Microsoft.AspNetCore.Identity;

namespace ComputerRepair.Infrastructure.Persistence.Repositories;

public sealed class RoleRepository : IRoleRepository
{
    private readonly RoleManager<CustomIdentityRole> _roleManager;

    public RoleRepository(RoleManager<CustomIdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> IsExistByIdAsync(RoleId roleId, CancellationToken cancellationToken = default)
    {
        return await _roleManager.FindByIdAsync(roleId.ToString()) != null;
    }
}
