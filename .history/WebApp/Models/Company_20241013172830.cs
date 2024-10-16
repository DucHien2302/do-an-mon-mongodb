namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Company
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("company_name")]
    public string CompanyName { get; set; }

    [BsonElement("profile_description")]
    public string ProfileDescription { get; set; }

    [BsonElement("establishment_date")]
    public DateTime EstablishmentDate { get; set; }

    [BsonElement("company_website_url")]
    public string CompanyWebsiteUrl { get; set; }

    [BsonElement("company_email")]
    public string CompanyEmail { get; set; }

    [BsonElement("company_images")]
    public List<CompanyImage> CompanyImages { get; set; }
}
