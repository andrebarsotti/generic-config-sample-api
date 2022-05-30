using Domain.Entities;

using FluentValidation;

using Range = Domain.Entities.Range;

namespace Domain.Validators;

public class FiltroRangeValidator : AbstractValidator<FiltroRange>
{
    public FiltroRangeValidator()
    {
        RuleFor(e => e.Nome).NotNull().NotEmpty();
        RuleFor(e => e.Valor).NotNull().SetValidator(new RangeValidator());
    }
}

public class RangeValidator : AbstractValidator<Range>
{
    public RangeValidator()
    {
        RuleFor(e => e.De).GreaterThan(0);
        RuleFor(e => e.Ate).GreaterThan(e => e.De);
    }
}
