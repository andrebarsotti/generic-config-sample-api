namespace Repositories;

using Domain.Entities;

using FluentAssertions;

using Repositories.Fixtures;

using Xunit;

public class RegraRepositoryTests : IClassFixture<RegraFixture>
{
    private readonly RegraRepositoryMongoDB _repository;
    private readonly RegraFixture _regraFixture;

    public RegraRepositoryTests(RegraFixture regraFixture)
    {
        _regraFixture = regraFixture;
        _repository = new RegraRepositoryMongoDB(regraFixture.MongoDatabase);
    }

    [Fact]
    public void AdicionarUmaRegraNoMongo()
    {
        // Setup
        Regra regra = _regraFixture.Regra;

        //Execução Add
        _repository.Add(regra);

        // Valiação GetById
        regra.Id.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void ObterRegraPorIdNoMongo()
    {
        // Setup
        Regra regra = _regraFixture.Regra;

        //Execução GetById
        var resultado = _repository.GetRegraById(regra.Id);

        // Validação GetById
        resultado.Should().NotBeNull()
                          .And
                          .NotBeSameAs(regra)
                          .And
                          .BeEquivalentTo(regra, config => config.Excluding(e => e.DataInclusao));

        // Validando o IFiltro
        foreach (IFiltro filtro in resultado.Filtros)
            FiltroTests.ValidarFiltro(filtro);
    }

    [Fact]
    public void ListarTodasAsRegrasCadastradas()
    {
        // Execução
        var resultado = _repository.GetAll();

        // Validação
        resultado.Should().NotBeNullOrEmpty();
    }
}
