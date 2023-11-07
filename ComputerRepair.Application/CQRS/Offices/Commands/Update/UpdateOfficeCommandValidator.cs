using FluentValidation;

namespace ComputerRepair.Application.CQRS.Offices.Commands.Update;

public sealed class UpdateOfficeCommandValidator : AbstractValidator<UpdateOfficeCommand>
{
    public UpdateOfficeCommandValidator()
    {
        RuleFor(x => x.OfficeId).NotEqual(Guid.Empty);
        RuleFor(x => x.NewTitle).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.NewRegion).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.NewCity).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.NewStreet).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.NewHome).MinimumLength(5).MaximumLength(50);
    }
}
