using ComputerRepair.Application.CQRS.Offices.Commands.Create;
using ComputerRepair.Application.CQRS.Offices.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepair.Api.Controllers;

[Route("api/offices")]
[ApiController]
public class OfficesController : ControllerBase
{
    private readonly ISender _sender;

    public OfficesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateAsync(CreateOfficeRequest request)
    {
        var result = await _sender.Send(new CreateOfficeCommand(
            request.Title,
            request.Region,
            request.City,
            request.Street,
            request.Home));
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _sender.Send(new GetAllOfficesQuery());
        return Ok(result);
    }
}
