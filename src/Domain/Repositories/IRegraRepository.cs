using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRegraRepository
    {
        void Add(Regra valor);
        Regra GetRegraById(string id);
    }
}
