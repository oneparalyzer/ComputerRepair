using ComputerRepair.Application.Common.Interfaces.Mediator;

namespace ComputerRepair.Application.CQRS.Users.Commands.Register;

public record RegisterUserCommand(
    string Email,
    string UserName,
    string Password,
    string PasswordConfirm,
    Guid RoleId) : ICommand;
