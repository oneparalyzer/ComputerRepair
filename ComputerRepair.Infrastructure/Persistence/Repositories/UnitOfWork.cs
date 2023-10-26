using ComputerRepair.Application.Common.Interfaces.Repositories;

namespace ComputerRepair.Infrastructure.Persistence.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(
        ApplicationDbContext context, 
        IRepairTypeRepository repairTypeRepository,
        IOfficeRepository officeRepository,
        IUserRepository userRepository)
    {
        _context = context;
        RepairTypeRepository = repairTypeRepository;
        OfficeRepository = officeRepository;
        UserRepository = userRepository;
    }

    public IUserRepository UserRepository { get; }
    public IOfficeRepository OfficeRepository { get; }
    public IRepairTypeRepository RepairTypeRepository { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
