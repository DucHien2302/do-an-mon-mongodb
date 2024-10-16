namespace WebApp.Models;

public class UserLoginRepository
{
    IMongoDBConnection connection;
    public UserLoginRepository(IMongoDBConnection connection) => (this.connection) = (connection);
    public IEnumerable<UserLogin> GetUserLogins()
    {

    }
}