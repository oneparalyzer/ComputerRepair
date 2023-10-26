namespace ComputerRepair.Contracts.Offices.Responses;

public class GetAllOfficesResponse
{
    public Guid OfficeId { get; set; }
    public string Title { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string Home { get; set; } = null!;
}
