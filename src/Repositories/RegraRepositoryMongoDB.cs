namespace Repositories;

using System.Collections.Generic;

using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;

using MongoDB.Driver;

public class RegraRepositoryMongoDB : IRegraRepository
{
    private readonly IMongoCollection<Regra> _colecao;

    public RegraRepositoryMongoDB(IMongoDatabase database)
    {
        _colecao = database.GetCollection<Regra>(DBConstants.RegrasEntity);
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
