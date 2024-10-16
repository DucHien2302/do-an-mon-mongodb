namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class JobPost
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("post_by_id")]
    public ObjectId PostById { get; set; }

    [BsonElement("job_title")]
    public string JobTitle { get; set; }

    [BsonElement("job_type")]
    public JobType JobType { get; set; }

    [BsonElement("created_date")]
    public DateTime CreatedDate { get; set; }

    [BsonElement("is_active")]
    public bool IsActive { get; set; }

    [BsonElement("job_description")]
    public string JobDescription { get; set; }

    [BsonElement("salary")]
    public decimal Salary { get; set; }

    [BsonElement("job_location")]
    public JobLocation JobLocation { get; set; }

    [BsonElement("category")]
    public JobCategory Category { get; set; }

    [BsonElement("file_description")]
    public string FileDescription { get; set; }
    [BsonElement("date_receiving_application")]
    public DateTime DateReceivingApplication { get; set; }
    [BsonElement("date_expire")]

    public DateTime DateExpire { get; set; }
}
