using Api.ViewModels;

using AutoMapper;

using Domain.Dto;
using Domain.Entities;

using Range = Domain.Entities.Range;

namespace Api.Mappers;

public sealed class VieModelProfile: Profile
{
    public VieModelProfile()
    {
        CreateMap<RegraVM, RegraDto>()
            .ForMember(src => src.Responsavel, opt => opt.MapFrom(src => src.IncluidoPor));
        CreateMap<Regra, RegraVM>();
        
        CreateMap<RegraResumoDto, RegraResumoVM>().ReverseMap();
        
        CreateMap<RangeVM, Range>().ReverseMap();

        CreateMap<ItemListaVM, ItemLista>().ReverseMap();
 
        CreateMap<FiltroVM, Filtro>().ConvertUsing<FiltroVMToFiltroConverter>();
        CreateMap<Filtro, FiltroVM>().ConvertUsing<FiltroToFiltroVMConverter>();
    }
}