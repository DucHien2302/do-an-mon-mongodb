namespace WebApp.Models;
using MongoDB.Bson;

public class CandidateFeedback
{
    public ObjectId Id { get; set; }
    public ObjectId UserAccountId { get; set; }
    public ObjectId JobPostId { get; set; }
    public ObjectId RecruitmentProcessId { get; set; }
    public DateTime FeedbackDate { get; set; }
    public string OverallExperience { get; set; }
    public string FeedbackComments { get; set; }
    public int Rating { get; set; }
}
