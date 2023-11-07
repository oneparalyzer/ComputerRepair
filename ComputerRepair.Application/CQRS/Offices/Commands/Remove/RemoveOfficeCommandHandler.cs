using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Remove;

public sealed class RemoveOfficeCommandHandler : ICommandHandler<RemoveOfficeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveOfficeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveOfficeCommand command, CancellationToken cancellationToken)
    {
        Office? officeById = await _unitOfWork.OfficeRepository
            .GetByIdAsync(OfficeId.Create(command.OfficeId), cancellationToken);

        if (officeById is null)
        {
            return Result.Failure(Errors.Office
                .NotFoundById(command.OfficeId.ToString())
                .ToList());
        }

        await _unitOfWork.OfficeRepository
            .RemoveAsync(officeById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
