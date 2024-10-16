namespace WebApp.Models;

public class Stage
{
    public string StageName { get; set; } = null!;
    public string StageStatus { get; set; } = null!;
    public DateTime? DateStarted { get; set; }
    public DateTime? DateCompleted { get; set; }
    public string Feedback { get; set; } = null!;
}