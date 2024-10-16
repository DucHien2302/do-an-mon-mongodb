namespace WebApp.Models;
using MongoDB.Bson;

public class JobType
{
    public ObjectId Id { get; set; }
    public string JobTypeName { get; set; }
}