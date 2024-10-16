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
    public IEnumerable<UserType> GetUserRolesByUserType()
    {
        // Lấy collection từ MongoDB
        var userAccountCollection = connection.GetCollection<UserAccount>("user_account");
        var userTypeCollection = connection.GetCollection<UserType>("user_type");

        // Thực hiện join giữa user_account và user_type dựa trên user_type_id
        var lookup = userAccountCollection.Aggregate()
            .Lookup<UserAccount, UserType, UserType>(
                userTypeCollection, // Tên collection để join
                u => u.UserTypeId,  // Field trong user_account để join (user_type_id)
                t => t.Id,          // Field trong user_type để join (_id)
                r => r.UserRoles    // Tên đầu ra sau khi join
            )
            .ToList();

        return lookup;
    }

}