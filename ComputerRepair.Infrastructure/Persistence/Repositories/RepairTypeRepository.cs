using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Infrastructure.Persistence.Repositories;

public sealed class RepairTypeRepository : IRepairTypeRepository
{
    private readonly ApplicationDbContext _context;

    public RepairTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(RepairType repairType, CancellationToken cancellationToken = default)
    {
        await _context.RepairTypes.AddAsync(repairType, cancellationToken);
    }

    public async Task<IEnumerable<RepairType>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.RepairTypes
            .ToListAsync(cancellationToken);
    }

    public async Task<RepairType?> GetByIdAsync(RepairTypeId repairTypeId, CancellationToken cancellationToken = default)
    {
        return await _context.RepairTypes
            .FirstOrDefaultAsync(x =>
                x.Id == repairTypeId,
                cancellationToken);
    }

    public async Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.RepairTypes
            .AnyAsync(x =>
                x.Title == title, 
                cancellationToken);
    }

    public async Task RemoveAsync(RepairType repairType, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.RepairTypes.Remove(repairType);
        }, cancellationToken);
    }

    public async Task UpdateAsync(RepairType repairType, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.RepairTypes.Update(repairType);
        }, cancellationToken);
    }
}
