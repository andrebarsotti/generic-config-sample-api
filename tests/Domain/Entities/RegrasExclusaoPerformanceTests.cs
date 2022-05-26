using System.Collections.Generic;
using Bogus;
using Domain.Enums;
using DomainTests.Fakers;

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
            Tipo = Tipo.Lista,
            Nome = _faker.Lorem.Sentence(),
            Valor = lista
        };

        // Execute
        RegrasExclusaoPerformance regra = new();
        regra.Filtros = new List<IFiltro>() { filtro };
    
        // Validate
        //regra.Filtros.Should()
    }
}