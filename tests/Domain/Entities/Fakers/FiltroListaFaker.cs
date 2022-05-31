using Domain.Fakers;

namespace Domain.Entities.Fakers;

using Bogus;

internal sealed class FiltroListaFaker : Faker<FiltroLista>
{
    public FiltroListaFaker(): base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Valor, _ => ItemListaFaker.GerarLista());
    }
}
