using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyWebApi.Models;

public abstract class CollectionBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}