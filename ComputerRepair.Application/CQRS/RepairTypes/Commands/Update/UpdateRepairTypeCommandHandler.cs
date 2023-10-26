using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Update;

public sealed class UpdateRepairTypeCommandHandler : ICommandHandler<UpdateRepairTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRepairTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRepairTypeCommand command, CancellationToken cancellationToken)
    {
        
        return Result.Success();
    }
}
