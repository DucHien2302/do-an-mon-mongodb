namespace WebApp.Models;
using MongoDB.Bson;

public class RecruitmentProcess
{
    public ObjectId Id { get; set; }
    public ObjectId JobPostId { get; set; }
    public ObjectId UserAccountId { get; set; }
    public string ProcessStatus { get; set; } = null!;
    public List<Stage> Stages { get; set; } = null!;
}
