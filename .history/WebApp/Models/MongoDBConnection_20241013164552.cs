using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApp.Models;

public class MongoDBConnection : IMongoDBConnection
{
    private readonly IMongoDatabase _database;

    public MongoDBConnection(IOptions<MongoDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}

public interface IMongoDBConnection
{
    IMongoCollection<T> GetCollection<T>(string name);
}