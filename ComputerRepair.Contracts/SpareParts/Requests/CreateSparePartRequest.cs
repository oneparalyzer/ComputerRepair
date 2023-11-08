namespace ComputerRepair.Contracts.SpareParts.Requests;

public record CreateSparePartRequest(
    string Title,
    int MeasureUnitId);
