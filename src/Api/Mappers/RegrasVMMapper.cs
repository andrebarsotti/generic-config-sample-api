using System.Text.Json;

using Api.ViewModels;

using Domain.Dto;
using Domain.Entities;
using Domain.Enums;

using Range = Domain.Entities.Range;

namespace Api.Mappers;

public static class RegrasVMMapper
{
    public static RegraDto ToRegraDto(this RegraVM model)
    {
        List<Filtro> filtrosRegra = new();
        RegraDto regra = new()
        {
            Nome = model.Nome,
            Filtros = filtrosRegra
        };

        if (model.Filtros is not null)
            foreach(FiltroVM filtro in model.Filtros)
                ConverterFiltro(filtro, filtrosRegra);

        return regra;
    }

    private static void ConverterFiltro(FiltroVM filtro, List<Filtro> filtrosRegra)
    {
        Filtro filtroConvertido = filtro.Tipo switch
        {
            Tipo.Lista => ConverterFiltroLista(filtro),
            Tipo.Range => ConverterFiltroRange(filtro),
            Tipo.Valor => ConverterFiltroValor(filtro),
            _ => throw new InvalidDataException(),
        };

        filtrosRegra.Add(filtroConvertido);
    }

    private static Filtro ConverterFiltroLista(FiltroVM filtro)
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

    private static Filtro ConverterFiltroValor(FiltroVM filtro)
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

    public static RegraVM ToRegraVM(this Regra regra)
    {
        List<FiltroVM> filtrosVM = new();
        RegraVM regraVm = new()
        {
            Nome = regra.Nome,
            DataInclusao = regra.DataInclusao.ToLocalTime(),
            IncluidoPor = regra.IncluidoPor,
            Filtros = filtrosVM
        };

        foreach(Filtro filtro in regra.Filtros)
            ConverterFiltro(filtro, filtrosVM);

        return regraVm;
    }

    private static void ConverterFiltro(Filtro filtro, List<FiltroVM> filtrosVM)
    {
        FiltroVM filtroConvertido = filtro.Tipo switch
        {
            Tipo.Lista => ConverterFiltroLista(filtro),
            Tipo.Range => ConverterFiltroRange(filtro),
            Tipo.Valor => ConverterFiltroValor(filtro),
            _ => throw new InvalidDataException(),
        };

        filtrosVM.Add(filtroConvertido);
    }

    private static FiltroVM ConverterFiltroValor(Filtro filtro)
    {
        FiltroValor filtroValor = (FiltroValor)filtro;

        return new FiltroVM()
        {
            Tipo = filtroValor.Tipo,
            Nome = filtroValor.Nome,
            Valor = JsonSerializer.SerializeToElement(filtroValor.Valor)
        };
    }

    private static FiltroVM ConverterFiltroRange(Filtro filtro)
    {
        FiltroRange filtroRange = (FiltroRange)filtro;

        RangeVM rangeVM = new()
        {
            De = filtroRange.Valor.De,
            Ate = filtroRange.Valor.Ate
        };

        return new FiltroVM()
        {
            Tipo = filtroRange.Tipo,
            Nome = filtroRange.Nome,
            Valor = JsonSerializer.SerializeToElement(rangeVM)
        };
    }

    private static FiltroVM ConverterFiltroLista(Filtro filtro)
    {
        FiltroLista filtroLista = (FiltroLista)filtro;

        List<ItemListaVM> listaVM = filtroLista.Valor.Select(item => new ItemListaVM
        {
            Id = item.Id,
            Descricao = item.Descricao
        }).ToList();

        return new FiltroVM()
        {
            Tipo = filtroLista.Tipo,
            Nome = filtroLista.Nome,
            Valor = JsonSerializer.SerializeToElement(listaVM)
        };
    }
}
