using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Remove;

public sealed class RemoveRepairTypeCommandHandler : ICommandHandler<RemoveRepairTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveRepairTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveRepairTypeCommand command, CancellationToken cancellationToken)
    {
        RepairType? repairTypeById = await _unitOfWork.RepairTypeRepository
           .GetByIdAsync(RepairTypeId.Create(command.RepairTypeId), cancellationToken);

        if (repairTypeById is null)
        {
            return Result.Failure(Errors.RepairType
                    .NotFoundById(command.RepairTypeId.ToString())
                    .ToList());
        }

        await _unitOfWork.RepairTypeRepository
            .RemoveAsync(repairTypeById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
