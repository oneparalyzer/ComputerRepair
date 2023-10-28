using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Contracts.RepairTypes.Responses;

namespace ComputerRepair.Application.CQRS.RepairTypes.Queries.GetAll;

public record GetAllRepairTypesQuery() : IQuery<IEnumerable<GetAllRepairTypesResponse>>;
