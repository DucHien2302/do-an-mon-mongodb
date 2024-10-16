namespace WebApp.Models;

public class ExperienceDetail
{
    public string JobTitle { get; set; } = null!;
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrentJob { get; set; }
    public string JobLocationCity { get; set; }
    public string JobLocationState { get; set; }
    public string JobLocationCountry { get; set; }
    public string Description { get; set; }
}