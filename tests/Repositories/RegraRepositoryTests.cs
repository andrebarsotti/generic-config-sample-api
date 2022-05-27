using System;

using Domain.Entities;
using Domain.Entities.Fakers;

using FluentAssertions;

using Xunit;

namespace Repositories;

public class RegraRepositoryTests
{
    private readonly RegraRepository _repository;

    public RegraRepositoryTests()
    {
        _repository = new RegraRepository();
    }

    [Fact]
    public void AdicionarUmaRegraNoMongoEObterPorId()
    {
        // Setup
        Regra regra = new RegraFaker();

        //Execução Add
        _repository.Add(regra);

        // Valiação GetById
        regra.Id.Should().NotBeNullOrEmpty();

        //Execução GetById
        var resultado = _repository.GetRegraById(regra.Id);

        // Validação GetById
        resultado.Should().NotBeNull()
                          .And
                          .NotBeSameAs(regra)
                          .And
                          .BeEquivalentTo(regra, config => config.Excluding(e => e.DataInclusao));

        // Validando o Filtro
        foreach(IFiltro filtro in resultado.Filtros)
            FiltroTests.ValidarFiltro(filtro);
    }
}
