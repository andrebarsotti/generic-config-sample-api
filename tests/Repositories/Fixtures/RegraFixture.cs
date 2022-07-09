using System;

using Bogus;

using Domain.Entities;
using Domain.Entities.Fakers;

using MongoDB.Driver;

using Repositories.Extensions;

namespace Repositories.Fixtures;

public sealed class RegraFixture : IDisposable
{
    private readonly MongoClient _mongoClient;
    private readonly string _databaseName;

    public RegraFixture()
    {
        ServiceExtension.MapDatabaseEntities();

        Regra = new RegraFaker();

        _databaseName = $"estudos_mongo{new Faker().Random.Hash(10)}";
        _mongoClient = new MongoClient("mongodb://localhost:27017");
        MongoDatabase = _mongoClient.GetDatabase(_databaseName);
    }

    public Regra Regra { get; }

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