using Bogus;

namespace Domain.Entities.Fakers;

internal sealed class FiltroListaFaker : Faker<FiltroLista>
{
    public FiltroListaFaker(): base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Valor, _ => ItemListaFaker.GerarLista());
    }
}
