
using Domain.Dto;
using Domain.Entities;
using Domain.Mappers;
using Domain.Repositories;

using FluentValidation;

namespace Domain.Services;

public class RegrasService : IRegrasService
{
    private readonly RegraRepository _repositories;
    private readonly IValidator<RegraDto> _validator;

    public RegrasService(RegraRepository repositories,
                         IValidator<RegraDto> validator)
    {
        _repositories = repositories;
        _validator = validator;
    }

    public Regra Adicionar(RegraDto dto)
    {
        _validator.ValidateAndThrow(dto);

        Regra regra = RegraDtoMapper.ToRegra(dto);
        regra.DataInclusao = DateTime.UtcNow;

        _repositories.Add(regra);
        return regra;
    }

    public Regra ObterPorId(string id)
        => _repositories.GetRegraById(id);

    public IEnumerable<RegraResumoDto> ListarTodas()
        => _repositories.GetAll();
}
