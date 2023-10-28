using AutoMapper;
using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Contracts.RepairTypes.Responses;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using ComputerRepair.Domain.Common.OperationResults;

namespace ComputerRepair.Application.CQRS.RepairTypes.Queries.GetAll;

public sealed class GetAllRepairTypesQueryHandler : IQueryHandler<GetAllRepairTypesQuery, IEnumerable<GetAllRepairTypesResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRepairTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetAllRepairTypesResponse>>> Handle(GetAllRepairTypesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<RepairType> repairTypes = await _unitOfWork.RepairTypeRepository
            .GetAllAsync(cancellationToken);

        var repairTypesResponse = _mapper
            .Map<IEnumerable<GetAllRepairTypesResponse>>(repairTypes);

        return Result.Success(repairTypesResponse);
    }
}
