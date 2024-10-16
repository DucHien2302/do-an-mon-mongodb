namespace WebApp.Models;

public class UserLoginRepository
{
    IMongoDBConnection connection;
    public UserLoginRepository(IMongoDBConnection connection) => (this.connection) = (connection);
    public UserLogin GetUserLogin(string email, string password)
    {
        var collection = connection.GetCollection<UserLogin>("user_account");
    }
}