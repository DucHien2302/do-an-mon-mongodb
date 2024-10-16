namespace WebApp.Models;

public class UserTypeRepository
{
    MongoDBConnection connection;
    public UserTypeRepository(MongoDBConnection connection)
    {
        this.connection = connection;
    }
    public IEnumerable<UserType> GetUserTypes()
    {
        IEnumerable<UserType> list = connection.GetCollection<UserType>();
    }
}