namespace WebApp.Models;
using MongoDB.Bson;

public class Stage
{
    public string StageName { get; set; } = null!;
    public string StageStatus { get; set; }
    public DateTime? DateStarted { get; set; }
    public DateTime? DateCompleted { get; set; }
    public string Feedback { get; set; }
}

public class RecruitmentProcess
{
    public ObjectId Id { get; set; }
    public ObjectId JobPostId { get; set; }
    public ObjectId UserAccountId { get; set; }
    public string ProcessStatus { get; set; }
    public List<Stage> Stages { get; set; }
}
