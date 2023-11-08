namespace ComputerRepair.Contracts.SpareParts.Responses;

public class GetAllSparePartsResponse
{
    public Guid SparePartId { get; set; }
    public string Title { get; set; } = null!;
    public string MeasureUnitTitle { get; set; } = null!;
}
