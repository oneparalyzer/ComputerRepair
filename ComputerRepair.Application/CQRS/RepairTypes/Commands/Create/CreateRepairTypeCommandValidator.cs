using FluentValidation;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Create;

public sealed class CreateRepairTypeCommandValidator : AbstractValidator<CreateRepairTypeCommand>
{
    public CreateRepairTypeCommandValidator()
    {
        RuleFor(x => x.OfficeId).NotEqual(Guid.Empty);
        RuleFor(x => x.Title).MinimumLength(5).MaximumLength(50);
    }
}
