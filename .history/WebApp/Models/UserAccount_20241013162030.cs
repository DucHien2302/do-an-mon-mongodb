namespace WebApp.Models;
using MongoDB.Bson;

public class UserAccount : UserRegister
{
    public ObjectId UserId { get; set; }
    public string Gender { get; set; } = null!;
    public bool IsActive { get; set; }
    public string UserImage { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public SeekerProfile SeekerProfile { get; set; } = null!;
    public List<EducationDetail> EducationDetails { get; set; } = null!;
    public List<ExperienceDetail> ExperienceDetails { get; set; } = null!;
}