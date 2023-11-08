using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Remove;

public sealed class RemoveSparePartCommandHandler : ICommandHandler<RemoveSparePartCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveSparePartCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveSparePartCommand command, CancellationToken cancellationToken)
    {
        SparePart? sparePart = await _unitOfWork.SparePartRepository
            .GetByIdAsync(SparePartId.Create(command.SparePartId), cancellationToken);

        if (sparePart is null)
        {
            return Result.Failure(Errors.SparePart
                .NotFoundById(command.SparePartId.ToString())
                .ToList());
        }

        await _unitOfWork.SparePartRepository
            .RemoveAsync(sparePart, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
