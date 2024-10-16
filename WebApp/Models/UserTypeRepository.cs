using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApp.Models;

public class UserTypeRepository
{
    IMongoDBConnection connection;
    public UserTypeRepository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }
    public IEnumerable<UserType> GetUserTypes()
    {
        var collection = connection.GetCollection<UserType>("user_type");
        return collection.Find(p => true).ToList();
    }
    public string GetUserTypeName(string userTypeId)
    {
        var userTypeCollection = connection.GetCollection<UserType>("user_type");
        var filter = Builders<UserType>.Filter.Eq(u => u.Id, new ObjectId(userTypeId));
        var userType = userTypeCollection.Find(filter).FirstOrDefault();
        if (userType == null)
        {
            return null;
        }
        // Trả về user_type_name
        return userType.UserTypeName;
    }

}