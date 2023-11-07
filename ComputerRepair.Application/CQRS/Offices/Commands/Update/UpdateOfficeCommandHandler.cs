using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Update;

public sealed class UpdateOfficeCommandHandler : ICommandHandler<UpdateOfficeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOfficeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOfficeCommand command, CancellationToken cancellationToken)
    {
        Office? office = await _unitOfWork.OfficeRepository
            .GetByIdAsync(OfficeId.Create(command.OfficeId), cancellationToken);

        if (office is null)
        {
            return Result.Failure(Errors.Office
                .NotFoundById(command.OfficeId.ToString())
                .ToList());
        }

        office.Update(
            command.NewTitle,
            Address.Create(
                command.NewRegion,
                command.NewCity,
                command.NewStreet,
                command.NewHome));

        await _unitOfWork.OfficeRepository
            .UpdateAsync(office, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
