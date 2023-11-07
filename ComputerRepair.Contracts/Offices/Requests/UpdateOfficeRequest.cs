namespace ComputerRepair.Contracts.Offices.Requests;

public record UpdateOfficeRequest(
    string NewTitle,
    string NewRegion,
    string NewCity,
    string NewStreet,
    string NewHome);
