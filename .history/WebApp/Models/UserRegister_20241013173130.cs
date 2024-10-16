using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class UserRegister
{
    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("password")]
    public string Password { get; set; }
    [BsonElement("contact_number")]
    public string ContactNumber { get; set; }
    public ObjectId Id { get; set; }
}