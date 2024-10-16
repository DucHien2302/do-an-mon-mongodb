namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class JobType
{
    [BsonElement("job_type_name")]
    public string JobTypeName { get; set; }
}