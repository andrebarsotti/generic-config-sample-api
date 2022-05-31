using Domain.Entities;

using FluentValidation;

namespace Domain.Validators;

public class FiltroRangeValidator : AbstractValidator<FiltroRange>
{
    public FiltroRangeValidator()
    {
        RuleFor(e => e.Nome).NotNull().NotEmpty();
        RuleFor(e => e.Valor).NotNull().SetValidator(new RangeValidator());
    }
}