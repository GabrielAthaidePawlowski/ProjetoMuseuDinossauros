using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DinoMuseum.API.Models;

public class Era
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    
    // Campo novo para imagem da Era
    public string? ImagemUrl { get; set; } 
}