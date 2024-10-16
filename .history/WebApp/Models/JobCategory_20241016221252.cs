namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class JobCategory
{
    [BsonElement("name")]
    public string Name { get; set; }
}