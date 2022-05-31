using Bogus;

using Domain.Entities.Fakers;
using Domain.Fakers;

namespace Domain.Dto.Fakers;

internal sealed class RegraDtoFaker: Faker<RegraDto>
{
    public RegraDtoFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Responsavel, fk => fk.Person.FullName);
        RuleFor(e => e.Filtros, _ => FiltroFaker.GerarListaDeFiltros());
    }
}
