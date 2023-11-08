using FluentValidation;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Create;

public sealed class CreateSparePartCommandValidator : AbstractValidator<CreateSparePartCommand>
{
    public CreateSparePartCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(5).MaximumLength(50);
    }
}
