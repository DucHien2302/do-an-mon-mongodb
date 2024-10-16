namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class JobCategory
{
    [BsonElement("id")]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }
}