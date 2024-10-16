namespace WebApp.Models;

public class SeekerProfile
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal CurrentSalary { get; set; }
    public string Currency { get; set; }
    public bool IsAnnuallyMonthly { get; set; }
    public string EmailContact { get; set; }
    public string FileCv { get; set; }
}