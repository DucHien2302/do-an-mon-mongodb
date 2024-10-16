using MongoDB.Bson;

namespace WebApp.Models;

public class UserRegister
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ContactNumber { get; set; } = null!;
    public ObjectId Id { get; set; }
}