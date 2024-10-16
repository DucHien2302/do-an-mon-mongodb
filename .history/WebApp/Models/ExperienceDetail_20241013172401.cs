using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class ExperienceDetail
{
    [BsonElement("job_title")]
    public string JobTitle { get; set; }

    [BsonElement("company_name")]
    public string CompanyName { get; set; }

    [BsonElement("start_date")]
    public DateTime StartDate { get; set; }

    [BsonElement("end_date")]
    public DateTime EndDate { get; set; }

    [BsonElement("is_current_job")]
    public bool IsCurrentJob { get; set; }

    [BsonElement("job_location_city")]
    public string JobLocationCity { get; set; }

    [BsonElement("job_location_state")]
    public string JobLocationState { get; set; }

    [BsonElement("job_location_country")]
    public string JobLocationCountry { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }
}