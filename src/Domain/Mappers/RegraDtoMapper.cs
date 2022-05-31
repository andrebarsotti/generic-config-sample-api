using Domain.Dto;
using Domain.Entities;

namespace Domain.Mappers;

public static class RegraDtoMapper
{
    public static Regra ToRegra(RegraDto dto)
    {
        Regra regra = new();

        regra.Nome = dto.Nome;
        regra.IncluidoPor = dto.Responsavel;
        regra.Filtros = dto.Filtros;

        return regra;
    }
}
