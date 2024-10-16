using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class UserRegister
{
    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("password")]
    public string Password { get; set; }
    public string ContactNumber { get; set; } = null!;
    public ObjectId Id { get; set; }
}