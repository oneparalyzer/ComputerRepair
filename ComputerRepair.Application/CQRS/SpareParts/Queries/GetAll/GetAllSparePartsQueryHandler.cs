using AutoMapper;
using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Contracts.SpareParts.Responses;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.Common.OperationResults;

namespace ComputerRepair.Application.CQRS.SpareParts.Queries.GetAll;

public sealed class GetAllSparePartsQueryHandler : IQueryHandler<GetAllSparePartsQuery, IEnumerable<GetAllSparePartsResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSparePartsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<GetAllSparePartsResponse>>> Handle(GetAllSparePartsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<SparePart> spareParts = await _unitOfWork.SparePartRepository
            .GetAllAsync(cancellationToken);

        var sparePartsResponse = _mapper
            .Map<IEnumerable<GetAllSparePartsResponse>>(spareParts);

        return Result.Success(sparePartsResponse);
    }
}
