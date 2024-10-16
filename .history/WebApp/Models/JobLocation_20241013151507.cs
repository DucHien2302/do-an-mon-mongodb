namespace WebApp.Models;
using MongoDB.Bson;

public class JobLocation
{
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Zip { get; set; } = null!;
}