namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class RecruitmentProcess
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("job_post_id")]
    public ObjectId JobPostId { get; set; }

    [BsonElement("user_account_id")]
    public ObjectId UserAccountId { get; set; }

    [BsonElement("process_status")]
    public string ProcessStatus { get; set; }

    [BsonElement("stages")]
    public List<Stage> Stages { get; set; }
}
