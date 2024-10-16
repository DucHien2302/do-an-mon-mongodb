namespace WebApp.Models;

public class SeekerProfile
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal CurrentSalary { get; set; }
    public string Currency { get; set; } = null!;
    public bool IsAnnuallyMonthly { get; set; }
    public string EmailContact { get; set; } = null!;
    public string FileCv { get; set; } = null!;
}