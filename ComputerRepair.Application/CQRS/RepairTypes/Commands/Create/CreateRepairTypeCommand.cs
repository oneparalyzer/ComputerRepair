using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Create;

public record CreateRepairTypeCommand(string Title, Guid OfficeId) : ICommand;
