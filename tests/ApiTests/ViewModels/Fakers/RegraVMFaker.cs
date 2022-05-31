using Api.Fakers;

namespace Api.ViewModels.Fakers;

using Bogus;

public sealed class RegraVMFaker : Faker<RegraVM>
{
    public RegraVMFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.DataInclusao, fk => fk.Date.Recent());
        RuleFor(e => e.IncluidoPor, fk => fk.Person.FullName);
        RuleFor(e => e.Filtros, fk => (new FiltroVMFaker()).Generate(fk.Random.Int(1,10)));
    }
}
