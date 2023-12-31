﻿namespace ComputerRepair.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IRoleRepository RoleRepository { get; }
    IUserRepository UserRepository { get; }
    IOfficeRepository OfficeRepository { get; }
    IRepairTypeRepository RepairTypeRepository { get; }
    ISparePartRepository SparePartRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
