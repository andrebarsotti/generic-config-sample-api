using Domain.Entities;

using FluentValidation;

namespace Domain.Validators;

public class ItemListaValidator : AbstractValidator<ItemLista>
{
    public ItemListaValidator()
    {
        RuleFor(e => e.Id).GreaterThan(0);
        RuleFor(e => e.Descricao).NotNull().NotEmpty();
    }
}