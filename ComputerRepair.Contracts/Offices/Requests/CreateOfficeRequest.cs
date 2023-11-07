namespace ComputerRepair.Application.CQRS.Offices.Commands.Create;

public record CreateOfficeRequest(
    string Title,
    string Region,
    string City,
    string Street,
    string Home,
    int OfficeTypeId);
