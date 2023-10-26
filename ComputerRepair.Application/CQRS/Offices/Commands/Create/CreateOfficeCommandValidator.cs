using FluentValidation;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Create;

public sealed class CreateOfficeCommandValidator : AbstractValidator<CreateOfficeCommand>
{
    public CreateOfficeCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.Region).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.City).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.Street).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.Home).MinimumLength(5).MaximumLength(50);
    }
}
