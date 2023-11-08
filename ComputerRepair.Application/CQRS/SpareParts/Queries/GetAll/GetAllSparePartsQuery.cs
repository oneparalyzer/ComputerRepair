using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Contracts.SpareParts.Responses;

namespace ComputerRepair.Application.CQRS.SpareParts.Queries.GetAll;

public record GetAllSparePartsQuery() : IQuery<IEnumerable<GetAllSparePartsResponse>>;
