namespace WebApp.Models;
using MongoDB.Bson;


public class JobCategory
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = null!;
}