using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DinoMuseum.API.Models;

public class Era
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; set; } = string.Empty; // Ex: Cretáceo Inferior
    public string Descricao { get; set; } = string.Empty;
}