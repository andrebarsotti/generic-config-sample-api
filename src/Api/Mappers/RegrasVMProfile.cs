using Api.ViewModels;

using AutoMapper;

using Domain.Dto;
using Domain.Entities;

namespace Api.Mappers;

public sealed class RegrasVMProfile: Profile
{
    public RegrasVMProfile()
    {
        CreateMap<RegraVM, RegraDto>();
        CreateMap<Regra, RegraVM>();
    }
}