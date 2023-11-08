using ComputerRepair.Application.Common.Interfaces.Mediator;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.RoleAggregate.ValueObjects;
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
            errors.Add(Errors.User
                .AlreadyExistByEmail(command.Email));
        }

        bool userAlreadyExistByUserName = await _unitOfWork.UserRepository
            .IsExistByUserNameAsync(command.UserName);

        if (userAlreadyExistByUserName)
        {
            errors.Add(Errors.User
                .AlreadyExistByUserName(command.UserName));
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        bool roleIdAlreadyExist = await _unitOfWork.RoleRepository
            .IsExistByIdAsync(RoleId.Create(command.RoleId), cancellationToken);

        if (roleIdAlreadyExist)
        {
            return Result.Failure(Errors.Role
                .NotFoundById(command.RoleId.ToString())
                .ToList());
        }

        Result<User> createUserResult = User.Create(
            EmailAddress.Create(command.Email),
            command.UserName,
            Password.Create(command.Password),
            new List<RoleId> 
            { 
                RoleId.Create(command.RoleId)
            });

        if (!createUserResult.IsSuccess)
        {
            return createUserResult;
        }

        await _unitOfWork.UserRepository.CreateAsync(createUserResult.Value);
        
        return Result.Success(createUserResult);
    }
}
