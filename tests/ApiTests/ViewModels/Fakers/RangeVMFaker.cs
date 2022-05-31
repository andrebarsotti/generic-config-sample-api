using Api.Fakers;

namespace Api.ViewModels.Fakers;

using Bogus;

internal sealed class RangeVMFaker : Faker<RangeVM>
{
    public RangeVMFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.De, fk => fk.Random.Int(0, 100));
        RuleFor(e => e.Ate, (fk, ent) => fk.Random.Int(ent.De, 200));
    }
}
