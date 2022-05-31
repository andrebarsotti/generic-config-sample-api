using Domain.Dto;
using Domain.Dto.Fakers;
using Domain.Entities;

using FluentAssertions;

using Xunit;

namespace Domain.Mappers;

public class RegraDtoMapperTests
{
    [Fact]
    public void Mapper()
    {
        // Setup 
        RegraDto dto = new RegraDtoFaker();

        // Executar
        Regra resultado = RegraDtoMapper.ToRegra(dto);

        // Validação
        resultado.Should().NotBeNull()
            .And
            .BeEquivalentTo(dto, config => config.ExcludingMissingMembers());
    }
}
