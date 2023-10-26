using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Infrastructure.Persistence.Repositories;

public sealed class OfficeRepository : IOfficeRepository
{
    private readonly ApplicationDbContext _context;

    public OfficeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Office office, CancellationToken cancellationToken = default)
    {
        await _context.Offices.AddAsync(office, cancellationToken);
    }

    public async Task<IEnumerable<Office>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Offices
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Offices
            .AnyAsync(x =>
                x.Title == title,
                cancellationToken);
    }
}
