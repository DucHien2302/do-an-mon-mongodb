using MongoDB.Driver;

namespace WebApp.Models;

public class UserAccountRepository
{
    IMongoDBConnection connection;
    public UserAccountRepository(IMongoDBConnection connection) => this.connection = connection;
    public UserLogin GetUserLogin(UserLogin obj)
    {
        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<UserAccount>("user_account");

        // Tạo bộ lọc để khớp với email và mật khẩu
        var filter = Builders<UserAccount>.Filter.Eq(x => x.Email, obj.Email) &
                     Builders<UserAccount>.Filter.Eq(x => x.Password, obj.Password);

        // Truy vấn để lấy người dùng phù hợp
        var userAccount = collection.Find(filter).FirstOrDefault();

        // Nếu không tìm thấy người dùng, trả về null hoặc xử lý theo cách khác
        if (userAccount == null)
        {
            return null;
        }

        // Chuyển đổi đối tượng UserAccount thành UserLogin (giả sử bạn muốn trả về đối tượng UserLogin)
        var userLogin = new UserLogin
        {
            Email = userAccount.Email,
            Password = userAccount.Password
            // Thiết lập các trường khác nếu cần...
        };

        return userLogin;
    }
    public void Register(UserRegister obj)
    {
        var user = new UserRegister
        {
            Id = ObjectId.GenerateNewId(),
            Email = obj.Email,
            Password = obj.Password,
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