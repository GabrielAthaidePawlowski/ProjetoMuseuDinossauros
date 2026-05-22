using MongoDB.Driver;

namespace DinoMuseum.API.Data;

// [SOLID - S] Single Responsibility: A única função desta classe é configurar e gerenciar a conexão com o banco de dados MongoDB.
public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration configuration)
{
    // Ele tenta pegar a variável de ambiente primeiro!
    var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI") 
                          ?? configuration.GetSection("MongoDbSettings:ConnectionString").Value;

    var databaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;

    var mongoClient = new MongoClient(connectionString);
    _database = mongoClient.GetDatabase(databaseName);
}

    public IMongoDatabase GetDatabase => _database;
}