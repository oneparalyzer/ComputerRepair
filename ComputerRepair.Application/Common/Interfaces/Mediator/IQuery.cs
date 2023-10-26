using ComputerRepair.Domain.Common.OperationResults;
using MediatR;

namespace ComputerRepair.Application.Common.Interfaces.Mediator;

public interface IQuery<TResposne> : IRequest<Result<TResposne>>
{
}
