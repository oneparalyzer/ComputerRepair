using ComputerRepair.Application.CQRS.Offices.Commands.Create;
using ComputerRepair.Application.CQRS.Offices.Commands.Remove;
using ComputerRepair.Application.CQRS.Offices.Commands.Update;
using ComputerRepair.Application.CQRS.Offices.Queries.GetAll;
using ComputerRepair.Application.CQRS.Offices.Queries.GetById;
using ComputerRepair.Contracts.Offices.Requests;
using ComputerRepair.Domain.Common.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ComputerRepair.Api.Controllers;

[Route("api/offices")]
[ApiController]
public sealed class OfficesController : ControllerBase
{
    private readonly ISender _sender;

    public OfficesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOfficeRequest request)
    {
        var result = await _sender.Send(new CreateOfficeCommand(
            request.Title,
            request.Region,
            request.City,
            request.Street,
            request.Home,
            request.OfficeTypeId));
        return Ok(result);
    }

    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOfficeRequest request)
    {
        var result = await _sender.Send(new UpdateOfficeCommand(
            id,
            request.NewTitle,
            request.NewRegion,
            request.NewCity,
            request.NewStreet,
            request.NewHome));
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _sender.Send(new GetAllOfficesQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var result = await _sender.Send(new GetOfficeByIdQuery(id));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var result = await _sender.Send(new RemoveOfficeCommand(id));
        return Ok(result);
    }
}
