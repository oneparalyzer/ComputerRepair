using ComputerRepair.Application.CQRS.SpareParts.Commands.Create;
using ComputerRepair.Application.CQRS.SpareParts.Commands.Remove;
using ComputerRepair.Application.CQRS.SpareParts.Commands.Update;
using ComputerRepair.Application.CQRS.SpareParts.Queries.GetAll;
using ComputerRepair.Contracts.SpareParts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepair.Api.Controllers;

[Route("api/spare-parts")]
[ApiController]
public sealed class SparePartsController : ControllerBase
{
    private readonly ISender _sender;

    public SparePartsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSparePartRequest request)
    {
        var result = await _sender
            .Send(new CreateSparePartCommand(request.Title, request.MeasureUnitId));

        return Ok(result);
    }

    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateSparePartRequest request)
    {
        var result = await _sender
            .Send(new UpdateSparePartCommand(id, request.NewTitle, request.NewMeasureUnitId));

        return Ok(result);
    }

    [HttpDelete("{id}/remove")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var result = await _sender
            .Send(new RemoveSparePartCommand(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _sender
            .Send(new GetAllSparePartsQuery());

        return Ok(result);
    }
}
