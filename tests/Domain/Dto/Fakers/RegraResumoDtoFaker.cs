using System.Collections.Generic;

using Bogus;

using Domain.Dto;
using Domain.Fakers;

namespace DomainTests.Dto.Fakers;

internal sealed class RegraResumoDtoFaker : Faker<RegraResumoDto>
{
    public RegraResumoDtoFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Id, fk => fk.Random.Hash());
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.DataInclusao, fk => fk.Date.Recent(2));
        RuleFor(e => e.IncluidoPor, fk => fk.Person.FullName);
    }

    public static IEnumerable<RegraResumoDto> GerarLista()
        => (new RegraResumoDtoFaker()).Generate((new Faker().Random.Int(1, 10)));
}
