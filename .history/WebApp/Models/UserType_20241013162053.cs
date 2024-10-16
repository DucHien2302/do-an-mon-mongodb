using MongoDB.Bson;

namespace WebApp.Models;

public class UserType
{
    public ObjectId UserTypeId { get; set; }
    public string UserTypeName { get; set; } = null!;
}