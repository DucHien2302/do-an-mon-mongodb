namespace WebApp.Models;
using MongoDB.Bson;

public class Interviewer
{
    public string Name { get; set; }
    public string Position { get; set; }
}

public class InterviewFeedback
{
    public string InterviewerName { get; set; }
    public string Comments { get; set; }
    public int Rating { get; set; }
}

public class InterviewSchedule
{
    public ObjectId Id { get; set; }
    public ObjectId JobPostId { get; set; }
    public ObjectId UserAccountId { get; set; }
    public string InterviewType { get; set; }
    public DateTime InterviewDate { get; set; }
    public JobLocation Location { get; set; }
    public List<Interviewer> Interviewers { get; set; }
    public List<InterviewFeedback> InterviewFeedback { get; set; }
}
