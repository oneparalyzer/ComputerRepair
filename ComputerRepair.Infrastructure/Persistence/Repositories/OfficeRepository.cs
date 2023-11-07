using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
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
            .Include(x => x.OfficeType)
            .ToListAsync(cancellationToken);
    }

    public async Task<Office?> GetByIdAsync(OfficeId officeId, CancellationToken cancellationToken = default)
    {
        return await _context.Offices
            .Include(x => x.OfficeType)
            .FirstOrDefaultAsync(x =>
                x.Id == officeId,
                cancellationToken);
    }

    public async Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Offices
            .AnyAsync(x =>
                x.Title == title,
                cancellationToken);
    }

    public async Task RemoveAsync(Office office, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Offices.Remove(office);
        }, cancellationToken);
    }

    public async Task UpdateAsync(Office office, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Offices.Update(office);
        }, cancellationToken);
    }
}
