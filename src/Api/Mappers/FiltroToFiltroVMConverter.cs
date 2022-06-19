using System.Text.Json;

using Api.ViewModels;

using AutoMapper;

using Domain.Entities;
using Domain.Enums;

using Range = Domain.Entities.Range;

namespace Api.Mappers;

public sealed class FiltroToFiltroVMConverter : ITypeConverter<Filtro, FiltroVM>
{
    public FiltroVM Convert(Filtro source, FiltroVM destination, ResolutionContext context)
        => new()
        {
            Tipo = source.Tipo,
            Nome = source.Nome,
            Valor = source.Tipo switch
            {
                Tipo.Lista => ConverterFiltroLista(((FiltroLista)source).Valor, context),
                Tipo.Range => ConverterFiltroRange(((FiltroRange)source).Valor, context),
                _ => JsonSerializer.SerializeToElement(((FiltroValor)source).Valor)
            }
        };

    private JsonElement ConverterFiltroRange(Range valor, ResolutionContext context)
        => JsonSerializer.SerializeToElement(context.Mapper.Map<RangeVM>(valor));

    private JsonElement ConverterFiltroLista(IEnumerable<ItemLista> valor, ResolutionContext context)
        => JsonSerializer.SerializeToElement(context.Mapper.Map<IEnumerable<ItemListaVM>>(valor));
}