using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;

namespace ComputerRepair.Application.Common.Interfaces.Repositories;

public interface IRepairTypeRepository
{
    Task CreateAsync(RepairType repairType, CancellationToken cancellationToken = default);
    Task<RepairType?> GetByIdAsync(RepairTypeId repairTypeId, CancellationToken cancellationToken = default);
    Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task UpdateAsync(RepairType sparePart, CancellationToken cancellationToken = default);
}
