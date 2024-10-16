namespace WebApp.Models;
using MongoDB.Bson;

public class CompanyImage
{
    public string CompanyImageUrl { get; set; }
}

public class Company
{
    public ObjectId Id { get; set; }
    public string CompanyName { get; set; }
    public string ProfileDescription { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public string CompanyWebsiteUrl { get; set; }
    public string CompanyEmail { get; set; }
    public List<CompanyImage> CompanyImages { get; set; }
}
