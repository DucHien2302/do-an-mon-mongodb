using MongoDB.Driver;

namespace WebApp.Models;

public class UserLoginRepository
{
    IMongoDBConnection connection;
    public UserLoginRepository(IMongoDBConnection connection) => (this.connection) = (connection);
    public UserLogin GetUserLogin(string email, string password)
    {
        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<UserAccount>("user_account");

        // Tạo bộ lọc để khớp với email và mật khẩu
        var filter = Builders<UserAccount>.Filter.Eq(x => x.Email, email) &
                     Builders<UserAccount>.Filter.Eq(x => x.Password, password);

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
            UserId = userAccount.Id,
            Email = userAccount.Email,
            // Thiết lập các trường khác nếu cần...
        };

        return userLogin;
    }

}