using Domain.Fakers;

namespace Domain.Entities.Fakers;

using Bogus;

internal sealed class FiltroRangeFaker : Faker<FiltroRange>
{
    public FiltroRangeFaker(): base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Valor, _ => new RangeFaker());
    }
}
