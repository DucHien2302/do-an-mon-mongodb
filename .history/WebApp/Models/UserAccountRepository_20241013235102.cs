using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApp.Models;

public class UserAccountRepository
{
    IMongoDBConnection connection;
    public UserAccountRepository(IMongoDBConnection connection) => this.connection = connection;
    public UserAccount GetUserAccount(UserLogin obj)
    {
        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<UserAccount>("user_account");

        // Tạo bộ lọc để khớp với email và mật khẩu
        var filter = Builders<UserAccount>.Filter.Eq(x => x.Email, obj.Email) &
                     Builders<UserAccount>.Filter.Eq(x => x.Password, Helper.HashPassword(obj.Password));

        // Truy vấn để lấy người dùng phù hợp
        var userAccount = collection.Find(filter).FirstOrDefault();

        // Nếu tìm thấy người dùng, trả về thông tin người dùng
        return userAccount;
    }
    public UserAccount GetUserAccount(string email)
    {
        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<UserAccount>("user_account");

        // Tạo bộ lọc để khớp với email và mật khẩu
        var filter = Builders<UserAccount>.Filter.Eq(x => x.Email, email) &
                     Builders<UserAccount>.Filter.Eq(x => x.Password, Helper.HashPassword(obj.Password));

        // Truy vấn để lấy người dùng phù hợp
        var userAccount = collection.Find(filter).FirstOrDefault();

        // Nếu tìm thấy người dùng, trả về thông tin người dùng
        return userAccount;
    }

    public void Register(UserRegister obj)
    {
        var user = new UserRegister
        {
            Id = ObjectId.GenerateNewId(),
            Email = obj.Email,
            Password = Helper.HashPassword(obj.Password),
            ContactNumber = obj.ContactNumber,
            UserTypeId = obj.UserTypeId
        };
        try
        {
            var collection = connection.GetCollection<UserRegister>("user_account");
            collection.InsertOne(user);
            return;
        }
        catch { }
    }
}