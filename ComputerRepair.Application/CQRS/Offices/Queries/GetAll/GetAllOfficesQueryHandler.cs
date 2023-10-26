using AutoMapper;
using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Contracts.Offices.Responses;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.Common.OperationResults;

namespace ComputerRepair.Application.CQRS.Offices.Queries.GetAll;

public sealed class GetAllOfficesQueryHandler : IQueryHandler<GetAllOfficesQuery, IEnumerable<GetAllOfficesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllOfficesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetAllOfficesResponse>>> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Office> offices = await _unitOfWork.OfficeRepository
            .GetAllAsync(cancellationToken);

        var officesResponse = _mapper
            .Map<IEnumerable<GetAllOfficesResponse>>(offices);

        return Result.Success(officesResponse);
    }
}
