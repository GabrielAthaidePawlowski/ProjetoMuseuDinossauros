using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DinoMuseum.API.Data;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration configuration)
    {
        // Lê a string de conexão do appsettings.json
        var connectionString = configuration.GetSection("MongoDbSettings:ConnectionString").Value;
        var databaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoDatabase GetDatabase => _database;
}