using Domain.Entities;

using FluentValidation;

namespace Domain.Validators;

public class FiltroValorValidator : AbstractValidator<FiltroValor>
{
    public FiltroValorValidator()
    {
        RuleFor(e => e.Nome).NotNull().NotEmpty();
        RuleFor(e => e.Valor).NotNull().NotEmpty();
    }
}
