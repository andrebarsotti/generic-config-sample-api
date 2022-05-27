using Domain.Entities.Fakers;
using Domain.Enums;

using FluentAssertions;

using Xunit;

namespace Domain.Entities;

public class FiltroTests
{
    [Theory]
    [InlineData(Tipo.Lista)]
    [InlineData(Tipo.Range)]
    [InlineData(Tipo.Valor)]
    public void ConverterParaTipoEspecifico(Tipo tipo)
    {
        IFiltro filtro = FiltroFaker.GerarFiltro(tipo);

        ValidarFiltro(filtro);
    }

    public static void ValidarFiltro(IFiltro filtro)
    {
        switch (filtro.Tipo)
        {
            case Tipo.Lista:
                ValidarTipoLista(filtro);
                break;
            case Tipo.Range:
                ValidarTipoRange(filtro);
                break;
            case Tipo.Valor:
                ValidarTipoValor(filtro);
                break;
        }
    }

    private static void ValidarTipoValor(IFiltro filtro)
    {
        FiltroValor filtroConvertido = (FiltroValor)filtro;

        filtroConvertido.Nome.Should().NotBeNullOrEmpty();
        filtroConvertido.Valor.Should().NotBeNullOrEmpty();
    }

    private static void ValidarTipoRange(IFiltro filtro)
    {
        FiltroRange filtroConvertido = (FiltroRange)filtro;

        filtroConvertido.Nome.Should().NotBeNullOrEmpty();
        filtroConvertido.Valor.De.Should().BePositive();
        filtroConvertido.Valor.Ate.Should().BePositive()
                                           .And
                                           .BeGreaterThan(filtroConvertido.Valor.De);
    }

    private static void ValidarTipoLista(IFiltro filtro)
    {
        FiltroLista filtroConvertido = (FiltroLista)filtro;

        filtroConvertido.Nome.Should().NotBeNullOrEmpty();
        filtroConvertido.Valor.Should().NotBeNullOrEmpty();
    }
}