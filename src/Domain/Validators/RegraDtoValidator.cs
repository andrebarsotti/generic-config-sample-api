using Domain.Dto;
using Domain.Entities;

using FluentValidation;

namespace Domain.Validators;

public class RegraDtoValidator : AbstractValidator<RegraDto>
{
    public RegraDtoValidator()
    {
        RuleFor(e => e.Nome).NotNull().NotEmpty();
        RuleFor(e => e.Responsavel).NotNull().NotEmpty();
        RuleFor(e => e.Filtros).NotNull().NotEmpty();
        RuleForEach(e => e.Filtros).SetInheritanceValidator(e =>
        {
            e.Add<FiltroLista>(new FiltroListaValidator());
            e.Add<FiltroRange>(new FiltroRangeValidator());
            e.Add<FiltroValor>(new FiltroValorValidator());
        });
    }
}
