namespace WebApp.Models;

public class Company
{
    public int Id { get; set; }
    public string Company_name { get; set; } = null!;
    public string Profile_description { get; set; } = null!;
    public DateTime Establishment_date { get; set; }

}