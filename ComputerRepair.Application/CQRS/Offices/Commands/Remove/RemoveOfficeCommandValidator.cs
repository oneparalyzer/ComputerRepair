using FluentValidation;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Remove;

public sealed class RemoveOfficeCommandValidator : AbstractValidator<RemoveOfficeCommand>
{
    public RemoveOfficeCommandValidator()
    {
        RuleFor(x => x.OfficeId).NotEqual(Guid.Empty);
    }
}
