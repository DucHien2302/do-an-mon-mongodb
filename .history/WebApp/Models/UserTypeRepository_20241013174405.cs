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
    public async Task<IEnumerable<UserType>> GetUserTypes()
    {
        var collection = connection.GetCollection<UserType>("user_type");
        return await collection.Find(p => true).ToListAsync();
    }
}