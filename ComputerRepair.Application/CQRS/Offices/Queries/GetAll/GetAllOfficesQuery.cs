using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Contracts.Offices.Responses;

namespace ComputerRepair.Application.CQRS.Offices.Queries.GetAll;

public record GetAllOfficesQuery() : IQuery<IEnumerable<GetAllOfficesResponse>>;
