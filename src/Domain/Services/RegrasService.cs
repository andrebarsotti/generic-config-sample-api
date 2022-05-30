
using Domain.Dto;
using Domain.Entities;
using Domain.Mappers;
using Domain.Repositories;

namespace Domain.Services;

public class RegrasService : IRegrasService
{
    private readonly RegraRepository _repositories;

    public RegrasService(RegraRepository repositories)
    {
        _repositories = repositories;
    }

    public Regra Adicionar(RegraDto dto)
    {
        // Aplicar Throw Validator

        Regra regra = RegraDtoMapper.ToRegra(dto);
        regra.DataInclusao = DateTime.UtcNow;

        _repositories.Add(regra);
        return regra;
    }
}
