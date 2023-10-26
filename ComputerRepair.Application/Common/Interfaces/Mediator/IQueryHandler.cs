using ComputerRepair.Domain.Common.OperationResults;
using MediatR;

namespace ComputerRepair.Application.Common.Interfaces.Mediator;

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
