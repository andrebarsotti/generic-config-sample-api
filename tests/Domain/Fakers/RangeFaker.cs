using Bogus;

namespace Domain.Fakers;

internal class RangeFaker : Faker<Entities.Range>
{
    public RangeFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.De, fk => fk.Random.Int(0, 100));
        RuleFor(e => e.Ate, (fk, ent) => fk.Random.Int(ent.De, 200));
    }
}
