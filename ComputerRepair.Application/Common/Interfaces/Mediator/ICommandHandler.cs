using ComputerRepair.Domain.Common.OperationResults;
using MediatR;

namespace ComputerRepair.Application.Common.Interfaces.Mediator;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> 
    where TCommand : ICommand
{
}
