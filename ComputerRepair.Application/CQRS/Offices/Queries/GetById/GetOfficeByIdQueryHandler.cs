using AutoMapper;
using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Contracts.Offices.Responses;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace ComputerRepair.Application.CQRS.Offices.Queries.GetById;

public sealed class GetOfficeByIdQueryHandler : IQueryHandler<GetOfficeByIdQuery, GetOfficeByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetOfficeByIdQueryHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetOfficeByIdResponse>> Handle(GetOfficeByIdQuery query, CancellationToken cancellationToken)
    {
        Office? office = await _unitOfWork.OfficeRepository
            .GetByIdAsync(OfficeId.Create(query.OfficeId), cancellationToken);

        if (office is null)
        {
            return Result.Failure<GetOfficeByIdResponse>(Errors.Office
                .NotFoundById(query.OfficeId.ToString())
                .ToList());
        }

        var officeResponse = _mapper
            .Map<GetOfficeByIdResponse>(office);

        return Result.Success(officeResponse);
    }
}
