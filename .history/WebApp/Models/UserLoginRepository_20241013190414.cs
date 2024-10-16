namespace WebApp.Models;

public class UserLoginRepository
{
    IMongoDBConnection connection;
    public UserLoginRepository(IMongoDBConnection connection)
    {

    }
}