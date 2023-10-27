using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Create;

public record CreateSparePartCommand(
    string Title,
    int MeasureUnitId) : ICommand;
