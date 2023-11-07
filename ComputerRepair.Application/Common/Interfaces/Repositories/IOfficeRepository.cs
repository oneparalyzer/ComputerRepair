using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace ComputerRepair.Application.Common.Interfaces.Repositories;

public interface IOfficeRepository
{
    Task CreateAsync(Office office, CancellationToken cancellationToken = default);
    Task<IEnumerable<Office>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Office?> GetByIdAsync(OfficeId officeId, CancellationToken cancellationToken = default);
    Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task RemoveAsync(Office office, CancellationToken cancellationToken = default);
    Task UpdateAsync(Office office, CancellationToken cancellationToken = default);
}
