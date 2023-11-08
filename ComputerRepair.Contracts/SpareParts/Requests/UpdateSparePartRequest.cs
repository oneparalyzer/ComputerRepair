namespace ComputerRepair.Contracts.SpareParts.Requests;

public record UpdateSparePartRequest(
    string NewTitle,
    int NewMeasureUnitId);
