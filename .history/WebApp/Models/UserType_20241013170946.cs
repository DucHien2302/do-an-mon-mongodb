using MongoDB.Bson;

namespace WebApp.Models;

public class UserType
{
    public ObjectId Id { get; set; }
    public string UserTypeName { get; set; } = null!;
}