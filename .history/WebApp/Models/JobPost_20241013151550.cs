namespace WebApp.Models;
using MongoDB.Bson;

public class JobPost
{
    public ObjectId Id { get; set; }
    public ObjectId PostById { get; set; }
    public JobType JobType { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public string JobDescription { get; set; } = null!;
    public decimal Salary { get; set; }
    public JobLocation JobLocation { get; set; } = null!;
    public JobCategory Category { get; set; } = null!;
    public string FileDescription { get; set; } = null!;
}
