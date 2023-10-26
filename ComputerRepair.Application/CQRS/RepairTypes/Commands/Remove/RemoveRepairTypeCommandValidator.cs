using FluentValidation;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Remove;

public sealed class RemoveRepairTypeCommandValidator : AbstractValidator<RemoveRepairTypeCommand>
{
    public RemoveRepairTypeCommandValidator()
    {
        RuleFor(x => x.RepairTypeId).NotEqual(Guid.Empty);
    }
}
