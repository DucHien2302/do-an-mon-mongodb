namespace WebApp.Models;
using MongoDB.Bson;

public class JobPost
{
    public ObjectId Id { get; set; }
    public ObjectId PostById { get; set; }
    public JobType JobType { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public string JobDescription { get; set; }
    public decimal Salary { get; set; }
    public JobLocation JobLocation { get; set; }
    public JobCategory Category { get; set; }
    public string FileDescription { get; set; }
}
