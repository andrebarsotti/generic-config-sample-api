using AutoMapper;

using Domain.Dto;
using Domain.Entities;

namespace Domain.Mappers;

public class RegraDtoProfile : Profile
{
    public RegraDtoProfile()
    {
        CreateMap<Regra, RegraDto>().ReverseMap();
    }
}