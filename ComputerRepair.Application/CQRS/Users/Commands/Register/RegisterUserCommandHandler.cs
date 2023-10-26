using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.UserAggregate;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.Common.OperationResults;

namespace ComputerRepair.Application.CQRS.Users.Commands.Register;

public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        bool userAlreadyExistByEmail = await _unitOfWork.UserRepository
            .IsExistByEmailAsync(EmailAddress.Create(command.Email));

        if (userAlreadyExistByEmail)
        {
            // добавить код
        }

        bool userAlreadyExistByUserName = await _unitOfWork.UserRepository
            .IsExistByUserNameAsync(command.UserName);

        if (userAlreadyExistByUserName)
        {
            // добавить код
        }

        //var user = User.Create(
        //    EmailAddress.Create(command.Email),
        //    command.UserName,
        //    Password.Create(command.Password),
        //    );
        throw new AggregateException();
    }
}
