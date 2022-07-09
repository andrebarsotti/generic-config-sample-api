using System.Text.Json;

using Api.ViewModels;

using AutoMapper;

using Domain.Entities;
using Domain.Enums;

using Range = Domain.Entities.Range;

namespace Api.Mappers;

public sealed class FiltroVMToFiltroConverter : ITypeConverter<FiltroVM, IFiltro>
{
    public IFiltro Convert(FiltroVM source, IFiltro destination, ResolutionContext context)
    =>  source.Tipo switch
        {
            Tipo.Lista => ConverterParaFiltroLista(source, context),
            Tipo.Range => ConverterParaFiltroRange(source, context),
            _ => ConverterParaFiltroValor(source)
        };

    private FiltroValor ConverterParaFiltroValor(FiltroVM source)
    {
        FiltroValor resultado = new();
        
        resultado.Nome = source.Nome;
        resultado.Valor = source.Valor.Deserialize<string>();

        return resultado;
    }

    private FiltroRange ConverterParaFiltroRange(FiltroVM source, ResolutionContext context)
    {
        FiltroRange resultado = new();
        RangeVM rangeVm = new();

        if (source.Valor.ValueKind == JsonValueKind.Object)
           rangeVm = source.Valor.Deserialize<RangeVM>() ?? new RangeVM();

        resultado.Nome = source.Nome;
        resultado.Valor = context.Mapper.Map<Range>(rangeVm);

        return resultado;
    }

    private FiltroLista ConverterParaFiltroLista(FiltroVM source, ResolutionContext context)
    {
        IEnumerable<ItemListaVM> lista = new List<ItemListaVM>();

        if (source.Valor.ValueKind == JsonValueKind.Array)
            lista = ConverterJsonElementParaItens(source.Valor);

        return new()
        {
            Nome = source.Nome,
            Valor = context.Mapper.Map<IEnumerable<ItemLista>>(lista)
        };
    }

    private static IEnumerable<ItemListaVM> ConverterJsonElementParaItens(JsonElement valor)
        => valor.Deserialize<IEnumerable<ItemListaVM>>() ?? new List<ItemListaVM>();    
}