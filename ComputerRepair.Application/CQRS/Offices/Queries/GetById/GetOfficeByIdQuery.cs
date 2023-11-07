using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Contracts.Offices.Responses;

namespace ComputerRepair.Application.CQRS.Offices.Queries.GetById;

public record GetOfficeByIdQuery(Guid OfficeId) : IQuery<GetOfficeByIdResponse>;
