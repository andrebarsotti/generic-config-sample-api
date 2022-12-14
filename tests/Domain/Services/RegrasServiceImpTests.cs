using System.Collections.Generic;

using AutoMapper;

using Bogus;

using Domain.Dto;
using Domain.Dto.Fakers;
using Domain.Entities;
using Domain.Entities.Fakers;
using Domain.Mappers;
using Domain.Repositories;

using DomainTests.Dto.Fakers;

using FluentAssertions;

using Moq;
using Moq.AutoMock;

using Xunit;

namespace Domain.Services;


public class RegrasServiceImpTests
{
    private readonly AutoMocker _autoMoq;
    private readonly Faker _faker;

    public RegrasServiceImpTests()
    {
        _autoMoq = new AutoMocker();
        _faker = new Faker();
        _autoMoq.Use<IMapper>(new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RegraDtoProfile>();
        })));
    }

    [Fact]
    public void AdicionarRegraPeloRepositorio()
    {
        // Setup
        RegraDto dto = new RegraDtoFaker();
        Mock<IRegraRepository> mock = _autoMoq.GetMock<IRegraRepository>();
        mock.Setup(repo => repo.Add(It.IsAny<Regra>()))
            .Callback<Regra>((regra) => regra.Id = _faker.Random.Hash())
            .Verifiable();
        
        // Execute
        var service = _autoMoq.CreateInstance<RegrasService>();
        Regra resultado = service.Adicionar(dto);

        // Validar
        mock.Verify();
        resultado.Should().NotBeNull()
            .And
            .BeEquivalentTo(dto, cfg => cfg.ExcludingMissingMembers());
        resultado.Id.Should().NotBeNullOrEmpty();

    }

    [Fact]
    public void ObterRegraPorId()
    {
        // Setup
        Regra regra = new RegraFaker();
        string id = _faker.Random.Hash();

        Mock<IRegraRepository> mock = _autoMoq.GetMock<IRegraRepository>();
        mock.Setup(repo => repo.GetRegraById(id))
            .Returns(regra)
            .Verifiable();

        // Execute
        var service = _autoMoq.CreateInstance<RegrasService>();
        Regra resultado = service.ObterPorId(id);

        // Validar
        mock.Verify();
        resultado.Should().BeSameAs(regra);
    }

    [Fact]
    public void ListarTodas()
    {
        // Setup
        IEnumerable<RegraResumoDto> lista = RegraResumoDtoFaker.GerarLista();

        Mock<IRegraRepository> mock = _autoMoq.GetMock<IRegraRepository>();
        mock.Setup(repo => repo.GetAll())
            .Returns(lista)
            .Verifiable();

        // Execute
        var service = _autoMoq.CreateInstance<RegrasService>();
        IEnumerable<RegraResumoDto> resultado = service.ListarTodas();

        // Validar
        mock.Verify();
        resultado.Should().BeSameAs(lista);
        resultado.Should().BeEquivalentTo(lista);

    }
}

