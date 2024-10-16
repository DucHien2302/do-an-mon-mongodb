using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class JobLocation
{
    [BsonElement("city")]
    public string City { get; set; }

    [BsonElement("state")]
    public string State { get; set; }

    [BsonElement("country")]
    public string Country { get; set; }

    [BsonElement("zip")]
    public string Zip { get; set; }
}