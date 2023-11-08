using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Create;

public sealed class CreateSparePartCommandHandler : ICommandHandler<CreateSparePartCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSparePartCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateSparePartCommand command, CancellationToken cancellationToken)
    {
        MeasureUnit? measureUnit = Enumeration
            .GetAll<MeasureUnit>()
            .FirstOrDefault(x => 
                x.Id == command.MeasureUnitId);

        if (measureUnit is null)
        {
            return Result.Failure(Errors.MeasureUnit
                .NotFoundById(command.MeasureUnitId.ToString())
                .ToList());
        }

        bool sparePartIsExistByTitle = await _unitOfWork.SparePartRepository
            .IsExistByTitleAsync(command.Title, cancellationToken);

        if (sparePartIsExistByTitle)
        {
            return Result.Failure(Errors.SparePart
                .AlreadyExistByTitle(command.Title)
                .ToList());
        }

        var sparePart = SparePart.Create(
            command.Title,
            measureUnit);

        await _unitOfWork.SparePartRepository
            .CreateAsync(sparePart, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
