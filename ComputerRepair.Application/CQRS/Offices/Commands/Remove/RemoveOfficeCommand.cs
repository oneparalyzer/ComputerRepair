using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Remove;

public record RemoveOfficeCommand(Guid OfficeId) : ICommand;
