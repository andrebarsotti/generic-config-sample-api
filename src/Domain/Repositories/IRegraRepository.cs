using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRegraRepository
    {
        Regra Add(Regra valor);
        Regra GetRegraById(Regra valor);
    }
}
