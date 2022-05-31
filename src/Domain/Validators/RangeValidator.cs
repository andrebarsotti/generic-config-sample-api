using FluentValidation;

using Range = Domain.Entities.Range;

namespace Domain.Validators;

public class RangeValidator : AbstractValidator<Range>
{
    public RangeValidator()
    {
        RuleFor(e => e.De).GreaterThan(0);
        RuleFor(e => e.Ate).GreaterThan(e => e.De);
    }
}