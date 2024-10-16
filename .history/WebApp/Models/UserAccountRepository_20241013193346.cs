namespace WebApp.Models;

public class UserAccountRepository
{
    IMongoDBConnection connection;
    public UserAccountRepository(IMongoDBConnection connection) => this.connection = connection;

}