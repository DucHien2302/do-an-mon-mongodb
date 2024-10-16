namespace WebApp.Models;
using MongoDB.Bson;

public class Interviewer
{
    public string Name { get; set; } = null!;
    public string Position { get; set; } = null!;
}