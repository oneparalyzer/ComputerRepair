using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Remove;

public record RemoveRepairTypeCommand(Guid RepairTypeId) : ICommand;
