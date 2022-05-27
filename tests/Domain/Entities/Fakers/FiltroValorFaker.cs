using Bogus;

namespace Domain.Entities.Fakers;

internal sealed class FiltroValorFaker : Faker<FiltroValor>
{
    public FiltroValorFaker()
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Valor, fk => fk.Lorem.Sentence());
    }
}
