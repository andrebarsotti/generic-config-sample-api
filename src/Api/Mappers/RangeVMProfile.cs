using Api.ViewModels;

using AutoMapper;

using Range = Domain.Entities.Range;

namespace Api.Mappers;

public sealed class RangeVMProfile: Profile
{
    public RangeVMProfile()
    {
        CreateMap<RangeVM, Range>().ReverseMap();
    }
}