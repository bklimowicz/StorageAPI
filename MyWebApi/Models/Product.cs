using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyWebApi.Models;

public class Product : CollectionBase
{
    [BsonElement("name")] public string Name { get; set; } = null!;
    [BsonElement("location")] public string Location { get; set; } = null!;
    [BsonElement("quantity")] public float Quantity { get; set; }
    [BsonElement("needResupply")] public bool NeedResupply { get; set; }
}