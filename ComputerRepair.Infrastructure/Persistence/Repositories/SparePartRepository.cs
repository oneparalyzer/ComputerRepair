using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Infrastructure.Persistence.Repositories;

public sealed class SparePartRepository : ISparePartRepository
{
    private readonly ApplicationDbContext _context;

    public SparePartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(SparePart sparePart, CancellationToken cancellationToken = default)
    {
        await _context.SpareParts.AddAsync(sparePart, cancellationToken);
    }

    public async Task<IEnumerable<SparePart>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SpareParts
            .Include(x => x.MeasureUnit)
            .ToListAsync(cancellationToken);
    }

    public async Task<SparePart?> GetByIdAsync(SparePartId sparePartId, CancellationToken cancellationToken = default)
    {
        return await _context.SpareParts
            .Include(x => x.MeasureUnit)
            .FirstOrDefaultAsync(x =>
                x.Id == sparePartId,
                cancellationToken);
    }

    public async Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.SpareParts
            .AnyAsync(x =>
                x.Title == title,
                cancellationToken);
    }

    public async Task RemoveAsync(SparePart sparePart, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.SpareParts.Remove(sparePart);
        }, cancellationToken);
    }

    public async Task UpdateAsync(SparePart sparePart, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.SpareParts.Update(sparePart);
        }, cancellationToken);
    }
}
