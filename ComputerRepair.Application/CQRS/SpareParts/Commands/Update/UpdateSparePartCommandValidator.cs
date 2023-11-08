using FluentValidation;

namespace ComputerRepair.Application.CQRS.SpareParts.Commands.Update;

public sealed class UpdateSparePartCommandValidator : AbstractValidator<UpdateSparePartCommand>
{
    public UpdateSparePartCommandValidator()
    {
        RuleFor(x => x.SparePartId).NotEqual(Guid.Empty);   
        RuleFor(x => x.NewTitle).MinimumLength(5).MaximumLength(50);
    }
}
