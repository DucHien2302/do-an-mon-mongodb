namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class JobType
{
    [BsonElement("id")]
    public ObjectId Id { get; set; }

    [BsonElement("job_type_name")]
    public string JobTypeName { get; set; }
}