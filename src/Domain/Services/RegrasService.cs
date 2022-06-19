using Domain.Dto;
using Domain.Entities;

namespace Domain.Services
{
    public interface RegrasService
    {
        Regra Adicionar(RegraDto dto);
        
        IEnumerable<RegraResumoDto> ListarTodas();

        Regra ObterPorId(string id);
    }
}