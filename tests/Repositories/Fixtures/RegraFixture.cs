namespace Repositories.Fixtures;

using Domain.Entities;
using Domain.Entities.Fakers;

public class RegraFixture
{
    private readonly Regra _regra;
    public RegraFixture()
    {
        _regra = new RegraFaker();
    }

    public Regra Regra => _regra;
}
