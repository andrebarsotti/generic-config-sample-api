using Domain.Fakers;

namespace Domain.Entities.Fakers;

using Bogus;

internal sealed class RangeFaker : Faker<Range>
{
    public RangeFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.De, fk => fk.Random.Int(0, 100));
        RuleFor(e => e.Ate, (fk, ent) => fk.Random.Int(ent.De, 200));
    }
}
