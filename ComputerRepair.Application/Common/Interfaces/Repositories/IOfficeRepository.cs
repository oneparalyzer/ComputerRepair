using ComputerRepair.Domain.AggregateModels.OfficeAggregate;

namespace ComputerRepair.Application.Common.Interfaces.Repositories;

public interface IOfficeRepository
{
    Task CreateAsync(Office office, CancellationToken cancellationToken = default);
    Task<IEnumerable<Office>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default);
}
