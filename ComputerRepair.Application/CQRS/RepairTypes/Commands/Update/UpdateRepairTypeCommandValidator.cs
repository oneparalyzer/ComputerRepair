using FluentValidation;

namespace ComputerRepair.Application.CQRS.RepairTypes.Commands.Update;

public sealed class UpdateRepairTypeCommandValidator : AbstractValidator<UpdateRepairTypeCommand>
{
    public UpdateRepairTypeCommandValidator()
    {
        RuleFor(x => x.RepairTypeId).NotEqual(Guid.Empty);
        RuleFor(x => x.NewTitle).MinimumLength(5).MaximumLength(50);
    }
}
