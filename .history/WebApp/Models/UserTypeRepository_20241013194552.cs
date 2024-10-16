using System.Collections.ObjectModel;
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

}