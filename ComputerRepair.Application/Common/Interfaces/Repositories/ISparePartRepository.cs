using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;

namespace ComputerRepair.Application.Common.Interfaces.Repositories;

public interface ISparePartRepository
{
    Task CreateAsync(SparePart sparePart, CancellationToken cancellationToken = default);
    Task<IEnumerable<SparePart>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<SparePart?> GetByIdAsync(SparePartId sparePartId, CancellationToken cancellationToken = default);
    Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task RemoveAsync(SparePart sparePart, CancellationToken cancellationToken = default);
    Task UpdateAsync(SparePart sparePart, CancellationToken cancellationToken = default);
}
