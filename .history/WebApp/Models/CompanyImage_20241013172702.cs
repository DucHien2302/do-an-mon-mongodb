using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class CompanyImage
{
    [BsonElement("company_image")]
    public string CompanyImage { get; set; }
}