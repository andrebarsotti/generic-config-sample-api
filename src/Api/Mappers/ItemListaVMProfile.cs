using Api.ViewModels;

using AutoMapper;

using Domain.Entities;

namespace Api.Mappers;

public sealed class ItemListaVMProfile: Profile
{
    public ItemListaVMProfile()
    {
        CreateMap<ItemListaVM, ItemLista>().ReverseMap();
    }
}