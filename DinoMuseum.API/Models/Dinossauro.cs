using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DinoMuseum.API.Models;

public class Dinossauro
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Dieta { get; set; } = string.Empty;
    public string Regiao { get; set; } = string.Empty;
    public string EraId { get; set; } = string.Empty;

    public string Descricao { get; set; }

    // Campo novo para a foto do Dinossauro
    public string? ImagemUrl { get; set; }
}