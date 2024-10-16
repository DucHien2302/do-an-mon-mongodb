namespace WebApp.Models;
using MongoDB.Bson;

public class JobPostActivity
{
    public ObjectId Id { get; set; }
    public ObjectId UserAccountId { get; set; }
    public ObjectId JobPostId { get; set; }
    public DateTime ApplyDate { get; set; }
    public bool IsAccepted { get; set; }
}
