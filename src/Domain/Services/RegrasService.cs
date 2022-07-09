
using AutoMapper;

using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;

using FluentValidation;

namespace Domain.Services;

public class RegrasService : IRegrasService
{
    private readonly IRegraRepository _repositories;
    private readonly IValidator<RegraDto> _validator;
    private readonly IMapper _mapper;

    public RegrasService(IRegraRepository repositories,
                         IValidator<RegraDto> validator,
                         IMapper mapper)
    {
        _repositories = repositories;
        _validator = validator;
        _mapper = mapper;
    }

    public Regra Adicionar(RegraDto dto)
    {
        _validator.ValidateAndThrow(dto);

        var regra = _mapper.Map<Regra>(dto);
        regra.DataInclusao = DateTime.UtcNow;

        _repositories.Add(regra);
        return regra;
    }

    public Regra ObterPorId(string id)
        => _repositories.GetRegraById(id);

    public IEnumerable<RegraResumoDto> ListarTodas()
        => _repositories.GetAll();
}
