using AutoMapper;

using Domain.Dto;
using Domain.Dto.Fakers;
using Domain.Entities;

using FluentAssertions;

using Xunit;

namespace Domain.Mappers;

public class RegraDtoProfileTests
{
    private readonly IMapper _mapper;

    public RegraDtoProfileTests()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RegraDtoProfile>();
        }));
    }

    [Fact]
    public void Mapper()
    {
        // Setup 
        RegraDto dto = new RegraDtoFaker();

        // Executar
        var resultado = _mapper.Map<Regra>(dto);

        // Validação
        resultado.Should().NotBeNull()
            .And
            .BeEquivalentTo(dto, config => config.ExcludingMissingMembers());
    }
}
