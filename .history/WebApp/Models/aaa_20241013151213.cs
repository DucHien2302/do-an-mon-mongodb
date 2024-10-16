namespace WebApp.Models;
using MongoDB.Bson;

public class UserAccount
{
    public ObjectId Id { get; set; }
    public ObjectId UserTypeId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
    public bool IsActive { get; set; }
    public string ContactNumber { get; set; }
    public string UserImage { get; set; }
    public DateTime RegistrationDate { get; set; }
    public SeekerProfile SeekerProfile { get; set; }
    public List<EducationDetail> EducationDetails { get; set; }
    public List<ExperienceDetail> ExperienceDetails { get; set; }
}