using ComputerRepair.Application.CQRS.RepairTypes.Commands.Create;
using ComputerRepair.Application.CQRS.RepairTypes.Commands.Remove;
using ComputerRepair.Application.CQRS.RepairTypes.Commands.Update;
using ComputerRepair.Application.CQRS.RepairTypes.Queries.GetAll;
using ComputerRepair.Contracts.RepairTypes.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepair.Api.Controllers;

[Route("api/repair-types")]
[ApiController]
public sealed class RepairTypesController : ControllerBase
{
    private readonly ISender _sender;

    public RepairTypesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRepairTypeRequest request)
    {
        var result = await _sender
            .Send(new CreateRepairTypeCommand(request.Title));

        return Ok(result);
    }

    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRepairTypeRequest request)
    {
        var result = await _sender
            .Send(new UpdateRepairTypeCommand(id, request.NewTitle));

        return Ok(result);
    }

    [HttpDelete("{id}/remove")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var result = await _sender
            .Send(new RemoveRepairTypeCommand(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _sender
            .Send(new GetAllRepairTypesQuery());

        return Ok(result);
    }
}
