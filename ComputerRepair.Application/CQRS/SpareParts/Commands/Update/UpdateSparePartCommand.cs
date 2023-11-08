using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Update;

public record UpdateSparePartCommand(
    Guid SparePartId,
    string NewTitle,
    int NewMeasureUnitId) : ICommand;
