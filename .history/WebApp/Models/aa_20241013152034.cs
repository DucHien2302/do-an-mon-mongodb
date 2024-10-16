namespace WebApp.Models;
using MongoDB.Bson;

public class InterviewSchedule
{
    public ObjectId Id { get; set; }
    public ObjectId JobPostId { get; set; }
    public ObjectId UserAccountId { get; set; }
    public string InterviewType { get; set; } = null!;
    public DateTime InterviewDate { get; set; }
    public JobLocation Location { get; set; } = null!;
    public List<Interviewer> Interviewers { get; set; } = null!;
    public List<InterviewFeedback> InterviewFeedback { get; set; } = null!;
}
