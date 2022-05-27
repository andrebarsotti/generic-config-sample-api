using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Domain.Entities;
using Domain.Repositories;

using MongoDB.Driver;


namespace Repositories;

public class RegraRepository : IRegraRepository
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Regra> _colecao;

    public RegraRepository()
    {
        _client = new MongoClient("mongodb://localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&3t.uriVersion=3&3t.connection.name=LOCALHOST&3t.alwaysShowAuthDB=true&3t.alwaysShowDBFromUserRole=true");
        _database = _client.GetDatabase("estudo_mongo_metadado");
        _colecao = _database.GetCollection<Regra>("Regras");
    }

    public void Add(Regra valor)
    {
        _colecao.InsertOne(valor);
    }

    public Regra GetRegraById(string id)
    {
        var filtro = Builders<Regra>.Filter.Eq(e => e.Id, id);
        var retorno = _colecao.Find(filtro);
        return retorno.FirstOrDefault();
    }
}
