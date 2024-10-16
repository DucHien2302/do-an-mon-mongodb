using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class UserRegister
{
    [BsonElement("email")]
    public string Email { get; set; } = null!;

    [BsonElement("password")]
    public string Password { get; set; } = null!;
    [BsonElement("contact_number")]
    public string ContactNumber { get; set; } = null!;
    [BsonElement("user_type_id")]
    public ObjectId UserTypeId { get; set; }
}
