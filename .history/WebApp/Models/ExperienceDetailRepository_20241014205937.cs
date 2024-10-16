namespace WebApp.Models;

public class ExperienceDetailRepository
{
    IMongoDBConnection connection;
    public ExperienceDetailRepository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }
}