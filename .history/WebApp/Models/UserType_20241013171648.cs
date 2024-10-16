using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models
{
    public class UserType
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("user_type_name")]
        public string UserTypeName { get; set; } = null!;
    }
}
