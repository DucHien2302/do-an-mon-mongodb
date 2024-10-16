namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class InterviewSchedule
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("job_post_id")]
    public ObjectId JobPostId { get; set; }

    [BsonElement("user_account_id")]
    public ObjectId UserAccountId { get; set; }

    [BsonElement("interview_type")]
    public string InterviewType { get; set; }

    [BsonElement("interview_date")]
    public DateTime InterviewDate { get; set; }

    [BsonElement("location")]
    public JobLocation Location { get; set; }

    [BsonElement("interviewers")]
    public List<Interviewer> Interviewers { get; set; }

    [BsonElement("interview_feedback")]
    public List<InterviewFeedback> InterviewFeedback { get; set; }
}

