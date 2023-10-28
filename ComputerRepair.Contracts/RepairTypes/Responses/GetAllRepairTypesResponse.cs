namespace ComputerRepair.Contracts.RepairTypes.Responses;

public class GetAllRepairTypesResponse
{
    public Guid RepairTypeId { get; set; }
    public string Title { get; set; } = null!;
}
