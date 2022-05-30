using System.Text.Json;

using Api.ViewModels;

using Domain.Dto;
using Domain.Entities;
using Domain.Enums;

using Range = Domain.Entities.Range;

namespace Api.Mappers;

public static class RegrasVMMapper
{
    public static RegraDto ToRegraDto(RegrasVM model)
    {
        List<Filtro> filtrosRegra = new();
        RegraDto regra = new()
        {
            Nome = model.Nome,
            Filtros = filtrosRegra
        };

        foreach(FiltroVM filtro in model.Filtros)
            ConverterFiltro(filtro, filtrosRegra);

        return regra;
    }

    private static void ConverterFiltro(FiltroVM filtro, List<Filtro> filtrosRegra)
    {
        Filtro filtroConvertido;

        switch (filtro.Tipo)
        {
            case Tipo.Lista:
                filtroConvertido = ConverterFiltroLista(filtro);
                break;
            case Tipo.Range:
                filtroConvertido = ConverterFiltroRange(filtro);
                break;
            case Tipo.Valor:
                filtroConvertido = ConverterFiltroValor(filtro);
                break;
            default:
                throw new InvalidDataException();
        }

        filtrosRegra.Add(filtroConvertido);
    }

    private static Filtro ConverterFiltroValor(FiltroVM filtro)
    {
        IEnumerable<ItemLista> lista;

        if (filtro.Valor.ValueKind == JsonValueKind.Array)
            lista = ConverterJsonElementParaItens(filtro.Valor)
                                                .Select(item => new ItemLista
                                                {
                                                    Id = item.Id,
                                                    Descricao = item.Descricao
                                                })
                                                .ToList();
        else
            lista = new List<ItemLista>();

        FiltroLista filtroLista = new()
        {
            Nome = filtro.Nome,
            Valor = lista
        };

        return filtroLista;
    }

    private static IEnumerable<ItemListaVM> ConverterJsonElementParaItens(JsonElement valor)
        => valor.Deserialize<IEnumerable<ItemListaVM>>() ?? new List<ItemListaVM>();

    private static Filtro ConverterFiltroRange(FiltroVM filtro)
    {
        Range range = new();
        
        if (filtro.Valor.ValueKind == JsonValueKind.Object)
        {
            RangeVM valor = filtro.Valor.Deserialize<RangeVM>() ?? new RangeVM();

            range.Ate = valor.Ate;
            range.De = valor.De;
        }

        FiltroRange filtroRange = new()
        {
            Nome = filtro.Nome,
            Valor = range
        };

        return filtroRange;
    }

    private static Filtro ConverterFiltroLista(FiltroVM filtro)
    {
        var valor = string.Empty;

        if (filtro.Valor.ValueKind == JsonValueKind.String)
        {
            valor = filtro.Valor.Deserialize<string>() ?? string.Empty;
        }

        FiltroValor filtroValor = new()
        {
            Nome = filtro.Nome,
            Valor = valor
        };

        return filtroValor;
    }
}
