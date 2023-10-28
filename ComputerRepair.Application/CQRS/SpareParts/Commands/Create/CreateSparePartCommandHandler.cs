﻿using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
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

    public Task<Result> Handle(CreateSparePartCommand command, CancellationToken cancellationToken)
    {
        MeasureUnit? measureUnit = Enumeration
            .GetAll<MeasureUnit>()
            .FirstOrDefault(x => 
                x.Id == command.MeasureUnitId);

        if (measureUnit is null)
        {

        }

        throw new NotImplementedException();
    }
}
