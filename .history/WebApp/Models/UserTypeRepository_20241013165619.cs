namespace WebApp.Models;

public class UserTypeRepository
{
    MongoDBConnection connection;
    public UserTypeRepository(MongoDBConnection connection)
    {
        this.connection = connection;
    }

}