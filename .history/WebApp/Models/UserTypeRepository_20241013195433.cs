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
    public string GetUserTypeName(string userTypeId)
    {
        // Lấy collection từ MongoDB
        var userTypeCollection = connection.GetCollection<UserType>("user_type");

        // Tạo bộ lọc dựa trên user_type_id
        var filter = Builders<UserType>.Filter.Eq(u => u.Id, new ObjectId(userTypeId));

        // Tìm user_type dựa trên user_type_id
        var userType = userTypeCollection.Find(filter).FirstOrDefault();

        // Kiểm tra nếu không tìm thấy kết quả
        if (userType == null)
        {
            return null; // Hoặc xử lý theo yêu cầu
        }

        // Trả về user_type_name
        return userType.UserTypeName;
    }

}