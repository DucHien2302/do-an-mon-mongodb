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
    public IEnumerable<UserType> GetUserTypes(string user_account_id)
    {
        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<UserType>("user_type");

        // Tạo bộ lọc dựa trên user_account_id
        var filter = Builders<UserType>.Filter.Eq(x => x.UserAccountId, user_account_id);

        // Truy vấn để lấy các UserType phù hợp
        return collection.Find(filter).ToList();
    }
}