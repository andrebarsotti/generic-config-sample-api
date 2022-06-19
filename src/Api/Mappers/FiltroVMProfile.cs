using Api.ViewModels;

using AutoMapper;

using Domain.Entities;

namespace Api.Mappers;

public sealed class FiltroVMProfile : Profile
{
    public FiltroVMProfile()
    {
        CreateMap<FiltroVM, Filtro>().ConvertUsing<FiltroVMToFiltroConverter>();
        CreateMap<Filtro, FiltroVM>().ConvertUsing<FiltroToFiltroVMConverter>();
    }
}