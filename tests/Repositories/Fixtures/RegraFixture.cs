using System;

using Bogus;

using MongoDB.Driver;

namespace Repositories.Fixtures;

using Domain.Entities;
using Domain.Entities.Fakers;

public class RegraFixture: IDisposable
{
    private readonly Regra _regra;
    private readonly MongoClient _mongoClient;
    private readonly string _databaseName;
    private readonly IMongoDatabase _mongoDatabase;

    public RegraFixture()
    {
        _databaseName = $"estudos_mongo{(new Faker()).Random.Hash(length: 10)}";
        _regra = new RegraFaker();
        _mongoClient = new MongoClient("mongodb://localhost:27017");
        _mongoDatabase = _mongoClient.GetDatabase(_databaseName);
    }

    public Regra Regra => _regra;

    public IMongoClient MongoClient => _mongoClient;

    public IMongoDatabase MongoDatabase => _mongoDatabase;

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
