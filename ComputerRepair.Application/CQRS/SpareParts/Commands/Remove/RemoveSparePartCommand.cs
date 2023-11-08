using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Remove;

public record RemoveSparePartCommand(Guid SparePartId) : ICommand;
