using Domain.Entities;

using FluentValidation;

namespace Domain.Validators;

public class FiltroListaValidator : AbstractValidator<FiltroLista>
{
    public FiltroListaValidator()
    {
        RuleFor(e => e.Nome).NotNull().NotEmpty();
        RuleFor(e => e.Valor).NotNull().NotEmpty();
        RuleForEach(e => e.Valor).SetValidator(new ItemListaValidator());
    }
}