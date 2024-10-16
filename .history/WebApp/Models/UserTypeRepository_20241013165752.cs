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
        var list = connection.GetCollection<UserType>("user_type");
    }
}