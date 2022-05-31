namespace Repositories;

using System.Collections.Generic;

using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;

using MongoDB.Driver;

public class RegraRepositoryMongoDB : RegraRepository
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Regra> _colecao;

    public RegraRepositoryMongoDB()
    {
        _client = new MongoClient("mongodb://localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&3t.uriVersion=3&3t.connection.name=LOCALHOST&3t.alwaysShowAuthDB=true&3t.alwaysShowDBFromUserRole=true");
        _database = _client.GetDatabase("estudo_mongo_metadado");
        _colecao = _database.GetCollection<Regra>("Regras");
    }

    public void Add(Regra valor)
    {
        _colecao.InsertOne(valor);
    }

    public IEnumerable<RegraResumoDto> GetAll()
    {
        var projectionBuilder = Builders<Regra>.Projection
                                        .Include(e => e.Id)
                                        .Include(e => e.Nome)
                                        .Include(e => e.DataInclusao)
                                        .Include(e => e.IncluidoPor);

        var retorno = _colecao.Find(Builders<Regra>.Filter.Empty)
                              .Project<RegraResumoDto>(projection: projectionBuilder);
        
        return retorno.ToList();
    }

    public Regra GetRegraById(string id)
    {
        FilterDefinition<Regra> filtro = Builders<Regra>.Filter.Eq(e => e.Id, id);
        IFindFluent<Regra, Regra> retorno = _colecao.Find(filtro);
        return retorno.FirstOrDefault();
    }
}
