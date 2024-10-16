using MongoDB.Bson;

namespace WebApp.Models;

public class UserType
{
    public ObjectId Id { get; set; }
    public string User_type_name { get; set; } = null!;
}