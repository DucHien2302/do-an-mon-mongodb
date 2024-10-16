namespace WebApp.Models;

public class ExperienceDetail
{
    public string JobTitle { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrentJob { get; set; }
    public string JobLocationCity { get; set; } = null!;
    public string JobLocationState { get; set; } = null!;
    public string JobLocationCountry { get; set; } = null!;
    public string Description { get; set; } = null!;
}