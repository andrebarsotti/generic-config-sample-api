using System.Collections.Generic;
using System.Linq;

using Bogus;

using Domain.Fakers;

using FluentAssertions;

using Xunit;

namespace Domain.Entities;

public class RegrasExclusaoPerformanceTests
{
    private readonly Faker _faker;

    public RegrasExclusaoPerformanceTests()
    {
        _faker = new Faker();
    }

    [Fact]
    public void IncluirUmItemDoTipoFiltroListaNoFiltro()
    {
        // Setup
        List<ItemLista> lista = new();
        lista.AddRange(ItemListaFaker.GenerateList());

        FiltroLista filtro = new()
        {
            Nome = _faker.Lorem.Sentence(),
            Valor = lista
        };

        // Execute
        RegrasExclusaoPerformance regra = new();
        regra.Filtros = new List<IFiltro>() { filtro };

        // Validate
        regra.Filtros.Single().Should().BeSameAs(filtro);
    }

    [Fact]
    public void IncluirUmItemDoTipoRangeNoFiltro()
    {
        FiltroRange filtro = new()
        {
            Nome = _faker.Lorem.Sentence(),
            Valor = new RangeFaker()
        };

        // Execute
        RegrasExclusaoPerformance regra = new();
        regra.Filtros = new List<IFiltro>() { filtro };

        // Validate
        regra.Filtros.Single().Should().BeSameAs(filtro);
    }

    [Fact]
    public void IncluirUmItemDoTipoValorNoFiltro()
    {
        FiltroValor filtro = new()
        {
            Nome = _faker.Lorem.Sentence(),
            Valor = _faker.Lorem.Sentence()
        };

        // Execute
        RegrasExclusaoPerformance regra = new();
        regra.Filtros = new List<IFiltro>() { filtro };

        // Validate
        regra.Filtros.Single().Should().BeSameAs(filtro);
    }
}