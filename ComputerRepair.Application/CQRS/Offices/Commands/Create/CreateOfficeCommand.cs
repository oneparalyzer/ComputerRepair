using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Create;

public record CreateOfficeCommand(
    string Title,
    string Region,
    string City,
    string Street,
    string Home) : ICommand;
