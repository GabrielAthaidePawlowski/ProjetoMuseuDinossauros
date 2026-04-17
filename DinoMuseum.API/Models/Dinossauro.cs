using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DinoMuseum.API.Models;

public class Dinossauro
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Nome")]
    public string Nome { get; set; } = string.Empty;

    [BsonElement("Especie")]
    public string Especie { get; set; } = string.Empty;

    [BsonElement("Dieta")]
    public string Dieta { get; set; } = string.Empty;

    [BsonElement("Regiao")]
    public string Regiao { get; set; } = string.Empty; // Ex: "Ceará, Brasil"

    [BsonElement("EraId")]
    public string EraId { get; set; } = string.Empty; // Relacionamento
}