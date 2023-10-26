using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Create;

public sealed class CreateRepairTypeCommandHandler : ICommandHandler<CreateRepairTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRepairTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateRepairTypeCommand command, CancellationToken cancellationToken)
    {
        bool repairTypeIsExistByTitle = await _unitOfWork.RepairTypeRepository
            .IsExistByTitleAsync(command.Title, cancellationToken);

        if (repairTypeIsExistByTitle)
        {
            return Result.Failure(Errors.RepairType
                    .AlreadyExistByTitle(command.Title)
                    .ToList());
        }

        //добавить проверку на существования офиса

        var sparePart = RepairType.Create(
            command.Title, 
            OfficeId.Create(command.OfficeId));

        await _unitOfWork.RepairTypeRepository.CreateAsync(sparePart, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
