namespace WebApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class UserAccount : UserRegister
{
    [BsonElement("registration_date")]
    public DateTime RegistrationDate { get; set; }

    [BsonElement("gender")]
    public bool Gender { get; set; }

    [BsonElement("is_active")]
    public bool IsActive { get; set; }

    [BsonElement("user_image")]
    public string UserImage { get; set; }

    [BsonElement("registration_date")]
    public DateTime RegistrationDate { get; set; }

    [BsonElement("seeker_profile")]
    public SeekerProfile SeekerProfile { get; set; }

    [BsonElement("education_details")]
    public List<EducationDetail> EducationDetails { get; set; }

    [BsonElement("experience_details")]
    public List<ExperienceDetail> ExperienceDetails { get; set; }
}