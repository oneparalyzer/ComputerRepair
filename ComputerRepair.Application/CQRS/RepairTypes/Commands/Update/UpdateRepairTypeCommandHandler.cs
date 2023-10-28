using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;

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
        RepairType? repairTypeById = await _unitOfWork.RepairTypeRepository
           .GetByIdAsync(RepairTypeId.Create(command.RepairTypeId), cancellationToken);

        if (repairTypeById is null)
        {
            return Result.Failure(Errors.RepairType
                    .NotFoundById(command.RepairTypeId.ToString())
                    .ToList());
        }

        repairTypeById.Update(command.NewTitle);

        await _unitOfWork.RepairTypeRepository.UpdateAsync(repairTypeById, cancellationToken);
        return Result.Success();
    }
}
