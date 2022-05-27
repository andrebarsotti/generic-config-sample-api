using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Domain.Entities;
using Domain.Repositories;

namespace Repositories;

public class RegraRepository : IRegraRepository
{
    public Regra Add(Regra valor)
    {
        Regra resultado = CreateDeepCopy(valor);
        resultado.Id = "Teste123";
        return resultado;
    }

    public Regra GetRegraById(Regra valor)
    {
        throw new NotImplementedException();
    }

    public static T CreateDeepCopy<T>(T obj)
    {
        using var ms = new MemoryStream();
        IFormatter formatter = new BinaryFormatter();
        formatter.Serialize(ms, obj);
        ms.Seek(0, SeekOrigin.Begin);
        return (T)formatter.Deserialize(ms);
    }
}
