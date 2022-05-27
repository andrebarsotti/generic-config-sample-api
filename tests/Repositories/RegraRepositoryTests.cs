using System;

using Domain.Entities;
using Domain.Entities.Fakers;

using FluentAssertions;

using Xunit;

namespace Repositories;

public class RegraRepositoryTests
{
    [Fact]
    public void Add()
    {
        // Setup
        Regra regra = new RegraFaker();

        //Execução
        RegraRepository repository = new();
        Regra resultado = repository.Add(regra);

        // Valiação
        resultado.Should().NotBeNull()
                          .And
                          .NotBeSameAs(regra)
                          .And
                          .BeEquivalentTo(regra, config => config.Excluding(e => e.Id));
        resultado.Id.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetRegraById()
    {
        throw new NotImplementedException();
    }
}
