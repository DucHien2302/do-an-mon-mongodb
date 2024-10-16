namespace WebApp.Models;


public class EducationDetailRepository
{
    IMongoDBConnection connection;
    public EducationDetailRepository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }

}