namespace Domain.Entities.Fakers;

using System.Collections.Generic;

using Bogus;

using Domain.Enums;

public static class FiltroFaker
{
    private static readonly Faker _faker = new();
    private static readonly FiltroListaFaker _filtroListaFaker = new();
    private static readonly FiltroRangeFaker _filtroRangeFaker = new();
    private static readonly FiltroValorFaker _filtroValorFaker = new();

    public static IEnumerable<IFiltro> GerarListaDeFiltros()
    {
        var filtros = new List<IFiltro>();
        var numeroMaximoItens = _faker.Random.Int(min: 1, max: 10);

        for (var contador = 0; contador < numeroMaximoItens; contador++)
            filtros.Add(GerarFiltro());

        return filtros;
    }

    public static IFiltro GerarFiltro() => GerarFiltro(_faker.Random.Enum<Tipo>());

    public static IFiltro GerarFiltro(Tipo tipo) => tipo switch
    {
        Tipo.Lista => _filtroListaFaker.Generate(),
        Tipo.Range => _filtroRangeFaker.Generate(),
        _ => _filtroValorFaker.Generate(),
    };
}
