using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.SeedWorks;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Update;

public sealed class UpdateSparePartCommandHandler : ICommandHandler<UpdateSparePartCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSparePartCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSparePartCommand command, CancellationToken cancellationToken)
    {
        SparePart? sparePart = await _unitOfWork.SparePartRepository
            .GetByIdAsync(SparePartId.Create(command.SparePartId), cancellationToken);

        if (sparePart is null)
        {
            return Result.Failure(Errors.SparePart
                .NotFoundById(command.SparePartId.ToString())
                .ToList());
        }

        MeasureUnit? measureUnit = Enumeration
            .GetAll<MeasureUnit>()
            .FirstOrDefault(x =>
                x.Id == command.NewMeasureUnitId);

        if (measureUnit is null)
        {
            return Result.Failure(Errors.MeasureUnit
                .NotFoundById(command.NewMeasureUnitId.ToString())
                .ToList());
        }

        bool sparePartIsExistByTitle = await _unitOfWork.SparePartRepository
            .IsExistByTitleAsync(command.NewTitle, cancellationToken);

        if (sparePartIsExistByTitle)
        {
            return Result.Failure(Errors.SparePart
                .AlreadyExistByTitle(command.NewTitle)
                .ToList());
        }

        sparePart.Update(
            command.NewTitle,
            measureUnit);

        await _unitOfWork.SparePartRepository
            .UpdateAsync(sparePart, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
