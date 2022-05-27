using Bogus;

namespace Domain.Entities.Fakers;

public sealed class RegraFaker : Faker<Regra>
{
    public RegraFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.DataInclusao, fk => fk.Date.Recent());
        RuleFor(e => e.IncluidoPor, fk => fk.Person.FullName);
        RuleFor(e => e.Filtros, _ => FiltroFaker.GerarListaDeFiltros());
    }
}
