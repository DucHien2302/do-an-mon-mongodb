namespace WebApp.Models;

public class InterviewFeedback
{
    public string InterviewerName { get; set; } = null!;
    public string Comments { get; set; } = null!;
    public int Rating { get; set; }
}