using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class Interviewer
{
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("position")]
    public string Position { get; set; }
}