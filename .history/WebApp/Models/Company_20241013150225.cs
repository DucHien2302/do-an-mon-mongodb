namespace WebApp.Models;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Profile_Description { get; set; } = null!;
    public string Establishment_date { get; set; }
}