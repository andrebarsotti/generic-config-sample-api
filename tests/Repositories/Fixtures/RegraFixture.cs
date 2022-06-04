using System;

using Bogus;

using Domain.Enums;

using MongoDB.Driver;

using Repositories.Extensions;

namespace Repositories.Fixtures;

using Domain.Entities;
using Domain.Entities.Fakers;

public class RegraFixture: IDisposable
{
    private readonly MongoClient _mongoClient;
    private readonly string _databaseName;

    public RegraFixture()
    {
        ServiceExtension.MapDatabaseEntities();
        
        Regra = new RegraFaker();
        //Regra.Filtros.Clear();
        //Regra.Filtros.Add(FiltroFaker.GerarFiltro(Tipo.Lista));
        
        _databaseName = $"estudos_mongo{(new Faker()).Random.Hash(length: 10)}";
        _mongoClient = new MongoClient("mongodb://localhost:27017");
        MongoDatabase = _mongoClient.GetDatabase(_databaseName);
    }

    public Regra Regra { get; }

    public IMongoClient MongoClient => _mongoClient;

    public IMongoDatabase MongoDatabase { get; }

    private void ReleaseUnmanagedResources()
    {
        _mongoClient.DropDatabase(_databaseName);
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~RegraFixture()
    {
        ReleaseUnmanagedResources();
    }
}
