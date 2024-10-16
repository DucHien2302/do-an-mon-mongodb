namespace WebApp.Models;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Profile_description { get; set; } = null!;
    public DateTime Establishment_date { get; set; }

}