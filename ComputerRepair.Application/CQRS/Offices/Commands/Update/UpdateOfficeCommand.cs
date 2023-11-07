using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Update;

public record UpdateOfficeCommand(
    Guid OfficeId,
    string NewTitle,
    string NewRegion,
    string NewCity,
    string NewStreet,
    string NewHome) : ICommand;
