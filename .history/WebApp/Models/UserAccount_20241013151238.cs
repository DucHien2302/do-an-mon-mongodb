namespace WebApp.Models;
using MongoDB.Bson;

public class UserAccount
{
    public ObjectId Id { get; set; }
    public ObjectId UserTypeId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public bool IsActive { get; set; }
    public string ContactNumber { get; set; } = null!;
    public string UserImage { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public SeekerProfile SeekerProfile { get; set; } = null!;
    public List<EducationDetail> EducationDetails { get; set; } = null!;
    public List<ExperienceDetail> ExperienceDetails { get; set; } = null!;
}