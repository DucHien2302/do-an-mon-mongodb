using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;
public class EducationDetail
{
    [BsonElement("certificate_degree_name")]
    public string CertificateDegreeName { get; set; }

    [BsonElement("institute_university_name")]
    public string InstituteUniversityName { get; set; }

    [BsonElement("starting_date")]
    public DateTime StartingDate { get; set; }

    [BsonElement("completion_date")]
    public DateTime CompletionDate { get; set; }

    [BsonElement("percentage")]
    public double Percentage { get; set; }

    [BsonElement("cgpa")]
    public double CGPA { get; set; }
}