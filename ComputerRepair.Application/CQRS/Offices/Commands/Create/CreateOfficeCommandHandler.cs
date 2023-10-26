﻿using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Create;

public sealed class CreateOfficeCommandHandler : ICommandHandler<CreateOfficeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOfficeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateOfficeCommand command, CancellationToken cancellationToken)
    {
        bool officeIsExistByTitle = await _unitOfWork.OfficeRepository
            .IsExistByTitleAsync(command.Title, cancellationToken);
        
        if (officeIsExistByTitle)
        {
            return Result.Failure(Errors.Office
                .AlreadyExistByTitle(command.Title)
                .ToList());
        }

        var office = Office.Create(
            command.Title,
            Address.Create(
                command.Region,
                command.City,
                command.Street,
                command.Home));

        await _unitOfWork.OfficeRepository
            .CreateAsync(office, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
