using Domain.Dto;
using Domain.Entities;

namespace Domain.Services
{
    public interface IRegrasService
    {
        Regra Adicionar(RegraDto dto);
    }
}