using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Update;

public record UpdateRepairTypeCommand(Guid RepairTypeId, string NewTitle) : ICommand;
