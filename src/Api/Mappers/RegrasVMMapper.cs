using System.Text.Json;

using Api.ViewModels;

using Domain.Dto;
using Domain.Entities;
using Domain.Enums;

namespace Api.Mappers;

public static class RegrasVMMapper
{
    public static RegraDto ToRegraDto(RegrasVM model)
    {
        RegraDto regra = new();

        regra.Nome = model.Nome;

        List<Filtro> filtrosRegra = new();
        regra.Filtros = filtrosRegra;


        FiltroVM filtro = model.Filtros.First();

        if (filtro.Tipo == Tipo.Lista && filtro.Valor.ValueKind == JsonValueKind.Array)
        {
            List<ItemLista> lista = new();
            FiltroLista filtroLista = new()
            {
                Nome = filtro.Nome,
                Valor = lista
            };

            IEnumerable<ItemListaVM> items = JsonSerializer.Deserialize<IEnumerable<ItemListaVM>>(filtro.Valor);

            foreach (ItemListaVM item in items)
            {
                lista.Add(new ItemLista
                {
                    Id = item.Id,
                    Descricao = item.Descricao
                });
            }

            filtrosRegra.Add(filtroLista);
        }

        return regra;
    }
}
