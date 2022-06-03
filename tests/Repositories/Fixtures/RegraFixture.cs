using System;

using Bogus;

using MongoDB.Driver;

namespace Repositories.Fixtures;

using Domain.Entities;
using Domain.Entities.Fakers;

public class RegraFixture: IDisposable
{
    private readonly MongoClient _mongoClient;
    private readonly string _databaseName;

    public RegraFixture()
    {
        _databaseName = $"estudos_mongo{(new Faker()).Random.Hash(length: 10)}";
        Regra = new RegraFaker();
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
