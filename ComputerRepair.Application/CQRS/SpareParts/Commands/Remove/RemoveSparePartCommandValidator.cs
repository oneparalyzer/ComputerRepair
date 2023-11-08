using FluentValidation;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Remove;

public sealed class RemoveSparePartCommandValidator : AbstractValidator<RemoveSparePartCommand>
{
    public RemoveSparePartCommandValidator()
    {
        RuleFor(x => x.SparePartId).NotEqual(Guid.Empty);
    }
}
