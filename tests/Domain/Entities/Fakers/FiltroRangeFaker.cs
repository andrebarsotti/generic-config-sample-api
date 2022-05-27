using Bogus;

namespace Domain.Entities.Fakers;

internal sealed class FiltroRangeFaker : Faker<FiltroRange>
{
    public FiltroRangeFaker(): base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Valor, _ => new RangeFaker());
    }
}
