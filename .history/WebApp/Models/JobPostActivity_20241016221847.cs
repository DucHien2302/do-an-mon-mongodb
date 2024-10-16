namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class JobPostActivity
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("user_account_id")]
    public ObjectId UserAccountId { get; set; }

    [BsonElement("job_post_id")]
    public ObjectId JobPostId { get; set; }

    [BsonElement("apply_date")]
    public DateTime ApplyDate { get; set; }

    [BsonElement("is_accepted")]
    public bool IsAccepted { get; set; }
}
