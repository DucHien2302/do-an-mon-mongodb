namespace WebApp.Models;
using MongoDB.Bson;

public class JobOffer
{
    public ObjectId Id { get; set; }
    public ObjectId JobPostId { get; set; }
    public ObjectId UserAccountId { get; set; }
    public DateTime OfferDate { get; set; }
    public string Position { get; set; }
    public decimal SalaryOffer { get; set; }
    public List<string> Benefits { get; set; }
    public string Status { get; set; }
    public DateTime ExpiryDate { get; set; }
}
