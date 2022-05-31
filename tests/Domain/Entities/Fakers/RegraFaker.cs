using Domain.Fakers;

namespace Domain.Entities.Fakers;

using Bogus;

public sealed class RegraFaker : Faker<Regra>
{
    public const string RuleSetRegraComId = "RegraComId";

    public RegraFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.DataInclusao, fk => fk.Date.Recent());
        RuleFor(e => e.IncluidoPor, fk => fk.Person.FullName);
        RuleFor(e => e.Filtros, _ => FiltroFaker.GerarListaDeFiltros());
        RuleSet(RuleSetRegraComId, set =>
                set.RuleFor(e => e.Id, fk => fk.Random.Hash())
            );
    }
}
